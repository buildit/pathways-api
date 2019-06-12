using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using pathways_api.Data.Mappers;

namespace pathways_api.Controllers
{
    public class SkillsController : PathwaysController
    {
        //Store skills info in Domo and Database
        
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
           //TODO: retrieve userskills from DB for domo
        }
    }
}