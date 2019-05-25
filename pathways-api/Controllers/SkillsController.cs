namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Mvc;
    using pathways_common.Controllers;
    using Services.Interfaces;

    public class SkillsController : ApiController
    {
        private readonly IRoleLevelService roleLevelService;
        private readonly IRoleTypeService roleTypeService;
        private readonly IMapper mapper;

        public SkillsController(IRoleLevelService roleLevelService, IRoleTypeService roleTypeService, IMapper mapper)
        {
            this.roleLevelService = roleLevelService;
            this.roleTypeService = roleTypeService;
            this.mapper = mapper;
        }

        [HttpGet("types")]
        public IActionResult GetAllTypes()
        {
            var results = this.roleTypeService.GetAll();
            IList<RoleTypeDto> userDtos = this.mapper.Map<IList<RoleTypeDto>>(results);
            return this.Ok(userDtos);
        }

        [HttpGet("levels")]
        public IActionResult GetAllLevels()
        {
            var results = this.roleLevelService.GetAll();
            IList<RoleLevelDto> userDtos = this.mapper.Map<IList<RoleLevelDto>>(results);
            return this.Ok(userDtos);
        }

        [HttpPost("levels/update")]
        public IActionResult UpdateLevels([FromBody] IList<RoleLevelDto> collection)
        {
            IList<RoleLevel> entityCollection = this.mapper.Map<IList<RoleLevel>>(collection);
            this.roleLevelService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }

        [HttpPost("types/update")]
        public IActionResult UpdateTypes([FromBody] IList<RoleTypeDto> collection)
        {
            IList<RoleType> entityCollection = this.mapper.Map<IList<RoleType>>(collection);
            this.roleTypeService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }
    }
}