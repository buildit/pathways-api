using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using pathways_api.Data.Mappers;
using pathways_api.Services.Interfaces;

namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    public class SkillsController : PathwaysController
    {
        //Store skills info in Domo and Database
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }
        
        // POST api/UsersSkills
        [HttpPost]
        public void PostUsersSkills(UserSkillDto userSkillSelection)
        {
            //TODO: Save user skill selection
        }
        
        // GET api/UsersSkills
        [HttpGet]    
        [Authorize(Policy = "ApiKeyPolicy")]
        public List<UserDto> GetUsersSkills()
        {
            var usersSkills = _skillsService.GetUsersSkills();

            return usersSkills;
        }
    }
}