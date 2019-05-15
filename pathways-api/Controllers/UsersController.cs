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

    public class UsersController : CacheResolvingController<User>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMemoryCache memoryCache, IMapper mapper)
            : base(userService, memoryCache)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            string authenticatedEmail = this.User.Claims.GetEmail();
            string authenticatedName = this.User.Claims.GetName();

            if (authenticatedEmail != userDto.Username) return this.BadRequest("Token and e-mail do not match.");

            User user = this.userService.RetrieveOrCreate(authenticatedEmail, authenticatedName);

            string tokenString = this.Request.Headers["Bearer"];

            return this.Ok(new
            {
                user.Id,
                user.DirectoryName,
                user.Username,
                Token = tokenString
            });
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<User> users = this.userService.GetAll();
            IList<UserDto> userDtos = this.mapper.Map<IList<UserDto>>(users);
            return this.Ok(userDtos);
        }
    }
}