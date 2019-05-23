using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using pathways_api.Data.Mappers;

namespace pathways_api.Controllers
{
    public class SkillsController : PathwaysController
    {
        //Store skills info in Domo and Database
        
        // POST api/values
        [HttpPost]
        public void PostUsersSkill(UserSkillDto userSkillSelection)
        {
            //if selection doesnt exist, create, otherwise update
        }
        
        // GET api/values
        [HttpGet]       
        public void GetUsersSkills()
        {
           
        }
        
        [HttpGet]       
        public void GetAccessToken()
        {

                    
        }
    }
}