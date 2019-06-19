namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using pathways_common.Controllers;
    using Services.Interfaces;

    public class SkillController : ApiController
    {
        private readonly ISkillLevelService levelService;
        private readonly IMapper mapper;
        private readonly ISkillTypeLevelService typeLevelService;
        private readonly ISkillTypeService typeService;
        private readonly ISkillsService skillsService;

        public SkillController(ISkillLevelService levelService, ISkillTypeService typeService, ISkillTypeLevelService typeLevelService, IMapper mapper, ISkillsService skillsService)
        {
            this.levelService = levelService;
            this.typeService = typeService;
            this.typeLevelService = typeLevelService;
            this.mapper = mapper;
            this.skillsService = skillsService;
        }

        [HttpGet("types")]
        public IActionResult GetAllTypes()
        {
            IEnumerable<SkillType> results = this.typeService.GetAll();
            IList<SkillTypeDto> userDtos = this.mapper.Map<IList<SkillTypeDto>>(results);
            return this.Ok(userDtos);
        }

        [HttpGet("levels")]
        public IActionResult GetAllLevels()
        {
            IEnumerable<SkillLevel> results = this.levelService.GetAll();
            IList<SkillLevelDto> userDtos = this.mapper.Map<IList<SkillLevelDto>>(results);
            return this.Ok(userDtos);
        }

        [HttpPost("levels/update")]
        public IActionResult UpdateLevels([FromBody] IList<SkillLevelDto> collection)
        {
            IList<SkillLevel> entityCollection = this.mapper.Map<IList<SkillLevel>>(collection);
            this.levelService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }

        [HttpPost("types/update")]
        public IActionResult UpdateTypes([FromBody] IList<SkillTypeDto> collection)
        {
            IList<SkillType> entityCollection = this.mapper.Map<IList<SkillType>>(collection);
            this.typeService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }

        [HttpPost("typelevel/update")]
        public IActionResult UpdateLevelTypes([FromBody] IList<SkillTypeLevelDto> collection)
        {
            IList<SkillTypeLevel> entityCollection = this.mapper.Map<IList<SkillTypeLevel>>(collection);
            this.typeLevelService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }
        
        //Store skills info in Domo and Database        
        // GET api/UsersSkills
        [HttpGet]    
        [Authorize(Policy = "ApiKeyPolicy")]
        public List<UserDto> GetUsersSkills()
        {
            var usersSkills = this.skillsService.GetUsersSkills();

            return usersSkills;
        }
    }
}