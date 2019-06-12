using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using pathways_api.Data.Mappers;
using pathways_api.Services.Interfaces;

namespace pathways_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase //PathwaysController
    {
        //private readonly DomoClient _domoClient;
        private readonly IGetUserDataService _getUserDataService;
        

        public UserDataController(IGetUserDataService getUserDataService)//DomoClient domoClient, 
        {
            //_domoClient = domoClient;
            _getUserDataService = getUserDataService;
        }

        // GET api/UserData
        [HttpGet]
        public async Task<List<UserDataDto>> GetUserDataAsync()
        {
            var accessToken = await _getUserDataService.GetAccessTokenAsync();
            var userData = await _getUserDataService.GetUsersDataAsync(accessToken);
           
            return userData;
        }
    }
}