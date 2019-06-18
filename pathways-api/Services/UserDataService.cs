using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pathways_api.Data.Mappers;
using pathways_api.Services.Interfaces;
using pathways_api.Data;

namespace pathways_api.Services
{
    public class userDataService : IUserDataService
    {            
        public async Task<string> GetAccessTokenAsync()
        {
            var domoClient = new HttpClient();
            var request = new HttpRequestMessage()
            {
                //TODO: move URL to app config
                RequestUri = new Uri("https://api.domo.com/oauth/token?grant_type=client_credentials&scope=data"),
                Method = HttpMethod.Get,
            };
            //TODO: move Both auth IDs to app config
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

            return domoKeyValue.First();
        }

        public async Task<List<DataSetDto>> GetDataSetsAsync(string accessToken)
        {
            var dataSetClient = new HttpClient();
            var dataSetRequest = new HttpRequestMessage()
            {
                //TODO: move URL to app config
                RequestUri = new Uri("https://api.domo.com/v1/datasets"),
                Method = HttpMethod.Get,
            };

            dataSetRequest.Headers.Add("Accept", "application/json");
            dataSetRequest.Headers.Add("Authorization", "bearer " + accessToken);
            
            var dataSetResponse = await dataSetClient.SendAsync(dataSetRequest).ConfigureAwait(false);

            dataSetResponse.EnsureSuccessStatusCode();
            var dataSetJson = await dataSetResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var dataSetArray = JArray.Parse(dataSetJson);
            
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            var dataSets = JsonConvert.DeserializeObject<List<DataSetDto>>(dataSetArray.ToString(), settings);

            return dataSets;
        }
        
        public async Task<List<UserDataDto>> GetUsersDataHeadersAsync(string accessToken)
        {            
            var userDataClient = new HttpClient();
            var dataSetRequest = new HttpRequestMessage()
            {
                //TODO: move URL and ID to app config
                RequestUri = new Uri("https://api.domo.com/v1/datasets/" + "8b209fa4-bb92-4b39-8e73-3f4183542129"),
                Method = HttpMethod.Get,
            };

            dataSetRequest.Headers.Add("Accept", "application/json");
            dataSetRequest.Headers.Add("Authorization", "bearer " + accessToken);
            
            var dataSetResponse = await userDataClient.SendAsync(dataSetRequest).ConfigureAwait(false);

            dataSetResponse.EnsureSuccessStatusCode();
            var dataSetJson = await dataSetResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var dataSetObject = JObject.Parse(dataSetJson);
            var dataSetArray = JArray.Parse(dataSetJson);

            return new List<UserDataDto>();
        }
        
        public async Task<List<UserDataDto>> GetUsersDataAsync(string accessToken)
        {
            var userDataClient = new HttpClient();
            userDataClient.DefaultRequestHeaders.Add("Accept", "application/json");
            userDataClient.DefaultRequestHeaders.Add("Authorization", "bearer " + accessToken);

            var userDataRequest = new UserDataRequest
            {
                sql = "SELECT * FROM table",
            };
            
            var userDatarequestJson = JsonConvert.SerializeObject(userDataRequest);
            
            //TODO: move URL to app config
            var url = "https://api.domo.com/v1/datasets/query/execute/8b209fa4-bb92-4b39-8e73-3f4183542129";
            
            var userDataResponse = userDataClient.PostAsync(url, new StringContent(userDatarequestJson, Encoding.UTF8, "application/json")).Result;
            userDataResponse.EnsureSuccessStatusCode();
            var dataSetJsonString = await userDataResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

           var usersData = ConvertUsersJsonToDto(dataSetJsonString);

           return usersData;
        }

        public List<UserDataDto> ConvertUsersJsonToDto(string usersDataJsonString)
        {
            dynamic dynObj = JsonConvert.DeserializeObject(usersDataJsonString);

            //The data we want to extract is within "rows" in the returned Json
            var rowData = dynObj.rows;

            var row = Convert.ToString(rowData);
            string[] dataRows = row.Split("],");
            var data = new List<string[]>();

            //Split each data column into its own line
            foreach (string rowinfo in dataRows)
            {
                var newRow = rowinfo.Split(",").ToArray();
                data.Add(newRow);
            }

            var userDataList = new List<UserDataDto>();

            foreach (var stuff in data.Where(x => x.Length == 25))
            {
                if (stuff[9].Contains("true")) //Using contains because there could be extra characters in the string and if there is no "true" then it's not worth going through the replace statment below
                {
                    //Remove misc characters and words - clean up formatting
                    var transformData = stuff.Select(x => x.Replace("studio=", "")
                            .Replace("band=", "")
                            .Replace(",", "")
                            .Replace("\"", "")
                            .Replace("location=", "")
                            .Replace("[", "")
                            .Replace("role=", ""))
                        .ToArray();

                    //trim excess white space
                    var trimmedData = transformData.Select(x => x.Trim()).ToArray();

                    //individually map each item in the array and parse or replace or convert if needed
                    var mappedData = new UserDataDto()
                    {
                        UserId = trimmedData[0] != "" ? Convert.ToInt64(trimmedData[0]) : 0,
                        UserEmail = trimmedData[1],
                        UserCreatedAt = trimmedData[2] != ""
                            ? DateTime.ParseExact(trimmedData[2].Replace("T", " "), "yyyy-MM-dd HH:mm:ss",
                                System.Globalization.CultureInfo.InvariantCulture)
                            : new DateTime(),
                        IsUserAdmin = trimmedData[3] == "true",
                        UserFirstName = trimmedData[4],
                        UserLastName = trimmedData[5],
                        UserTimezone = trimmedData[6],
                        IsUserContractor = trimmedData[7] == "true",
                        UserTelephone = trimmedData[8],
                        IsUserActive = trimmedData[9] == "true",
                        HasAccessToAllFutureProjects = trimmedData[10] == "true",
                        UserHourlyRate = trimmedData[11] != "" ? decimal.Parse(trimmedData[11]) : 0,
                        UserDepartment = trimmedData[12],
                        WantsNewsletterSubscription = trimmedData[13] == "true",
                        UserUpdatedAt = trimmedData[14] != ""
                            ? DateTime.ParseExact(trimmedData[14].Replace("T", " "), "yyyy-MM-dd HH:mm:ss",
                                System.Globalization.CultureInfo.InvariantCulture)
                            : new DateTime(),
                        IsUserProjectManager = trimmedData[15] == "true",
                        UserCostRate = trimmedData[16] != "" ? decimal.Parse(trimmedData[16]) : 0,
                        UserWeeklyCapacity = trimmedData[17] != "" ? Convert.ToDouble(trimmedData[17]) : 0,
                        Band = trimmedData[18],
                        Location = trimmedData[19],
                        UserRole = trimmedData[20],
                        Studio = trimmedData[21],
                        UserSampleData = trimmedData[22],
                        BatchId = trimmedData[23] != "" ? Convert.ToDouble(trimmedData[23]) : 0,
                        BatchLastRan = trimmedData[24] != ""
                            ? DateTime.ParseExact(trimmedData[24].Replace("T", " "), "yyyy-MM-dd HH:mm:ss",
                                System.Globalization.CultureInfo.InvariantCulture)
                            : new DateTime()
                    };

                    userDataList.Add(mappedData);
                }
            }

            return userDataList;
        }


        private string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}