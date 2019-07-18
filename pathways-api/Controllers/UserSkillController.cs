namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using pathways_common.Authentication.Extensions;
    using pathways_common.Controllers;
    using Services.Interfaces;

    public class UserSkillController : CacheResolvingController<User>
    {
        private readonly IMapper mapper;
        private readonly IUserSkillService service;

        public UserSkillController(IUserSkillService service, IMapper mapper, IUserService userService, IMemoryCache memoryCache)
            : base(userService, memoryCache)
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
            string authenticatedEmail = this.User.Claims.GetEmail();
            int userId = this.GetUserId(authenticatedEmail);
            userSkill.UserId = userId;
            UserSkill skillEntity = this.mapper.Map<UserSkill>(userSkill);
            UserSkill existingSkill = this.service.Retrieve(userSkill.UserId, userSkill.SkillTypeId);

            if (existingSkill != null)
            {
                existingSkill.SkillLevelId = userSkill.SkillLevelId;
                skillEntity = existingSkill;
            }

            this.service.Update(skillEntity);
            return this.Ok(skillEntity);
        }
    }
}