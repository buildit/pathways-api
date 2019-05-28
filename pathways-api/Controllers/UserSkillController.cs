namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Mvc;
    using pathways_common.Controllers;
    using Services.Interfaces;

    public class UserSkillController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IUserSkillService service;

        public UserSkillController(IUserSkillService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{username}")]
        public IActionResult GetUserSkills(string username)
        {
            IEnumerable<UserSkill> results = this.service.GetAll().Where(u => u.User.Username == username);
            IList<UserSkillDto> ruleDtos = this.mapper.Map<IList<UserSkillDto>>(results);
            return this.Ok(ruleDtos);
        }

        [HttpPost("update")]
        public IActionResult UpdateRange([FromBody] IList<UserSkillDto> collection)
        {
            IList<UserSkill> entityCollection = this.mapper.Map<IList<UserSkill>>(collection);
            this.service.UpdateRange(entityCollection, true);
            return this.Ok(entityCollection.Count);
        }

        [HttpPost]
        public IActionResult UpdateOrCreate([FromBody] UserSkillDto userSkill)
        {
            UserSkill skillEntity = this.mapper.Map<UserSkill>(userSkill);
            this.service.Update(skillEntity);
            return this.Ok(skillEntity);
        }
    }
}