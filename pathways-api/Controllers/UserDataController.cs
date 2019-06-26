using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pathways_api.Data.Mappers;
using pathways_api.Services.Interfaces;

namespace pathways_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase //PathwaysController
    {
        //private readonly DomoClient _domoClient;
        private readonly IUserDataService _userDataService;

        public UserDataController(IUserDataService userDataService) //DomoClient domoClient, 
        {
            //_domoClient = domoClient;
            _userDataService = userDataService;
        }

        // GET api/UserData
        [HttpGet]
        public async Task<List<UserDataDto>> GetUserDataAsync()
        {
            var accessToken = await _userDataService.GetAccessTokenAsync();
            var userData = await _userDataService.GetUsersDataAsync(accessToken);

            return userData;
        }
    }
}