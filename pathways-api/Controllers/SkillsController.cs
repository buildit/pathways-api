using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using pathways_api.Data.Mappers;
using pathways_api.Services.Interfaces;

namespace pathways_api.Controllers
{
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
        public void GetUsersSkills()
        {
            var usersSkills = _skillsService.GetUsersSkills();
        }
    }
}