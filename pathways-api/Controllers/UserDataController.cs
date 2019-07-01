namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Mappers;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase //PathwaysController
    {
        //private readonly DomoClient _domoClient;
        private readonly IUserDataService _userDataService;

        public UserDataController(IUserDataService userDataService) //DomoClient domoClient, 
        {
            //_domoClient = domoClient;
            this._userDataService = userDataService;
        }

        // GET api/UserData
        [HttpGet]
        public async Task<List<UserDataDto>> GetUserDataAsync()
        {
            string accessToken = await this._userDataService.GetAccessTokenAsync();
            List<UserDataDto> userData = await this._userDataService.GetUsersDataAsync(accessToken);

            return userData;
        }
    }
}