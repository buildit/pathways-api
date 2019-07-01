using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.Identity.Client;
    using Services.Interfaces;

    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public ServiceController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet("userskills")]
        public IActionResult GetUsersSkills()
        {
            List<User> users = this.userService.GetUsersSkills();
            List<UserSkilledDto> userDtos = this.mapper.Map<List<UserSkilledDto>>(users);

            return this.Ok(userDtos);
        }
    }
}