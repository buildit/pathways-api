using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using pathways_api.Data.Mappers;

namespace pathways_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase //PathwaysController
    {
        //Get bench info from Domo

        private readonly DomoClient _domoClient;

        public UserDataController() //DomoSettings domoSettings)//IOptions<DomoSettings> domoSettingsAccessor)
        {
            // _domoSettings = domoSettingsAccessor.Value;
            _domoClient = new DomoClient();
        }

        // GET api/UserData
        [HttpGet]
        public async Task<UserDataRequestDto> GetUserDataAsync()
        {

            //get access token 
            //move to service seperatly reusable

            var domoClient = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.domo.com/oauth/token?grant_type=client_credentials&scope=data"),
                Method = HttpMethod.Get,
            };
            var AuthorizationString = "b8ac9139-d8f6-4bff-b7c8-34167d242ee6" + ":" +
                                      "73f47d8f10cfb960aa3ac3b2c6647ceeccf2788c6b13259de018e74dd6abe617";
            var encodedAuthorizationString = Base64Encode(AuthorizationString);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Basic " + encodedAuthorizationString);

            var domoResponse = await domoClient.SendAsync(request).ConfigureAwait(false);

            domoResponse.EnsureSuccessStatusCode();
            var aouthJson = await domoResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var aouthObject = JObject.Parse(aouthJson);

            var domoKeyValue = aouthObject.Descendants().OfType<JProperty>().Where(p => p.Name == "access_token")
                .Select(x => x.Value.ToString()).ToArray();


            //access userData
            var userdata = new UserDataRequestDto();

            var userDataClient = new HttpClient();
            var userDataRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.domo.com/v1/datasets"),//"/8b209fa4-bb92-4b39-8e73-3f4183542129"),
                Method = HttpMethod.Get,
            };

            userDataRequest.Headers.Add("Accept", "application/json");
            userDataRequest.Headers.Add("Authorization", "bearer " + domoKeyValue.First());
            
            var userDataResponse = await userDataClient.SendAsync(userDataRequest).ConfigureAwait(false);

                // userdata = map response to userdatarequestdto
                //var data = await userDataResponse.Content.ReadAsAsync<UserDataRequestDto>(); //getting output
                var userDataJson = await userDataResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var userDataObject = JObject.Parse(userDataJson);

            return userdata;
        }
    
        
        //move to service
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}

//query examples
//.get('/data/v1/sales?fields=rep,amount&groupby=rep') --groupby rep
//https://developer.domo.com/docs/dev-studio-samples/data-queries