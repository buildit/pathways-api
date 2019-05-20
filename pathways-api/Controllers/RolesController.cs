namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using pathways_common.Controllers;
    using pathways_common.Extensions;
    using Services.Interfaces;

    public class RolesController : ApiController
    {
        private readonly IRoleLevelService roleLevelService;
        private readonly IRoleTypeService roleTypeService;
        private readonly IMapper mapper;

        public RolesController(IRoleLevelService roleLevelService, IRoleTypeService roleTypeService, IMapper mapper)
        {
            this.roleLevelService = roleLevelService;
            this.roleTypeService = roleTypeService;
            this.mapper = mapper;
        }

        [HttpGet("types")]
        public IActionResult GetAllTypes()
        {
            var results = this.roleTypeService.GetAll();
            IList<UserDto> userDtos = this.mapper.Map<IList<UserDto>>(results);
            return this.Ok(userDtos);
        }

        [HttpGet("levels")]
        public IActionResult GetAllLevels()
        {
            var results = this.roleLevelService.GetAll();
            IList<UserDto> userDtos = this.mapper.Map<IList<UserDto>>(results);
            return this.Ok(userDtos);
        }

        [HttpPost("levels/update")]
        public IActionResult UpdateAllLevels([FromBody] IList<RoleLevelDto> collection)
        {
            IList<RoleLevel> entityCollection = this.mapper.Map<IList<RoleLevel>>(collection);
            this.roleLevelService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }

        [HttpPost("types/update")]
        public IActionResult UpdateAllTypes([FromBody] IList<RoleTypeDto> collection)
        {
            IList<RoleType> entityCollection = this.mapper.Map<IList<RoleType>>(collection);
            this.roleTypeService.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }
    }
}