namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRoleLevelRuleService roleLevelRuleService;
        private readonly IUserService userService;

        public ServiceController(IMapper mapper, IUserService userService, IRoleLevelRuleService roleLevelRuleService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.roleLevelRuleService = roleLevelRuleService;
        }

        [HttpGet("userskills")]
        public IActionResult GetUsersSkills()
        {
            List<User> users = this.userService.GetUsersSkills();
            List<UserSkilledDto> userDtos = this.mapper.Map<List<UserSkilledDto>>(users);

            return this.Ok(userDtos);
        }

        [HttpGet("rolelevelrules")]
        public IActionResult GetRoleLevelRules()
        {
            List<RoleLevelRule> users = this.roleLevelRuleService.GetAllLoaded().ToList();
            List<RoleLevelRuleExpandedDto> userDtos = this.mapper.Map<List<RoleLevelRuleExpandedDto>>(users);

            return this.Ok(userDtos);
        }
    }
}