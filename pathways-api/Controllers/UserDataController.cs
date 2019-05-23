using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using pathways_api.Data.Mappers;

namespace pathways_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase//PathwaysController
    {
        //Get bench info from Domo

        private readonly DomoClient _domoClient;

        public UserDataController()//DomoSettings domoSettings)//IOptions<DomoSettings> domoSettingsAccessor)
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
            var request = new HttpRequestMessage() {
                RequestUri = new Uri("https://api.domo.com/oauth/token?grant_type=client_credentials&scope=data"),
                Method = HttpMethod.Get,
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jsonObject"));
            //request.Headers.Add("clientId", "9a224ad1-38e1-48c0-af0f-2c3be9f5c6d8");//(_domoClient.ClientId));
            //request.Headers.Add("secret", "53d5d3c25e9f0cf7e3ff947d709f6e05cbfcdf9eb659ab8cc81f40522d3306a5");//(_domoClient.ClientId));
            //request.Headers.Add("Content-Type", "application/jsonObject");
            var AuthorizationString = "9a224ad1-38e1-48c0-af0f-2c3be9f5c6d8" + ":" +
                                      "53d5d3c25e9f0cf7e3ff947d709f6e05cbfcdf9eb659ab8cc81f40522d3306a5";
            var encodedAuthorizationString = Base64Encode(AuthorizationString);
            request.Headers.Add("Authorization", "Basic " + encodedAuthorizationString);




            var localStorage = "";
            
            var domoResponse = await domoClient.PostAsync(request.RequestUri, new FormUrlEncodedContent(parameters));
            var contents = await response.Content.ReadAsStringAsync();
            
            
            
            var task = domoClient.SendAsync(request)
                .ContinueWith((taskwithmsg) =>
                {
                    var response = taskwithmsg.Result;
                    localStorage= "Bearer " + response.Content.Headers.
                                      
                    var jsonTask = response.Content.ReadAsAsync<JsonObjectContract>();
                    jsonTask.Wait();
                    var jsonObject = jsonTask.Result;
                });
            //task.Wait();


            //access userData
            var userdata = new UserDataRequestDto();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.domo.com/v1/datasets/8b209fa4-bb92-4b39-8e73-3f4183542129");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(_domoClient.DataSetsUrl + _domoClient.BenchDataSetId)
                        .ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        // userdata = map response to userdatarequestdto
                        var data = await response.Content.ReadAsAsync<UserDataRequestDto>(); //getting output

                    }

                    return userdata;
                }
            }

            catch (Exception e)
            {
                return userdata;
            }
        }
        
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}

// programs requesting access tokens has to know the client secret in order to gain the token
//client secret authorizes an app to request access tokens, it doesnt authenticate the user

//query examples
//.get('/data/v1/sales?fields=rep,amount&groupby=rep') --groupby rep
//https://developer.domo.com/docs/dev-studio-samples/data-queries