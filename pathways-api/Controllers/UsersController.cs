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
        private readonly IMapper mapper;
        private readonly IUserService userService;

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

            string tokenString = this.Request.Headers["Authorization"];

            return this.Ok(new
            {
                user.Id,
                user.Username,
                user.DomoIdentifier,
                Token = tokenString
            });
        }

        [HttpGet("{username}")]
        public IActionResult GetByName(string username)
        {
            User users = this.userService.Retrieve(username);
            UserDto userDto = this.mapper.Map<UserDto>(users);
            return this.Ok(userDto);
        }

        [HttpPut("{username}")]
        public IActionResult Update(string username, [FromBody] UserDto user)
        {
            User dbUser = this.userService.Retrieve(username);
            User newUser = this.mapper.Map<User>(user);

            dbUser.DirectoryName = newUser.DirectoryName;
            dbUser.Name = newUser.Name;

            this.userService.Update(dbUser);
            return this.Ok(newUser);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<User> users = this.userService.GetAll();
            IList<UserDto> userDtos = this.mapper.Map<IList<UserDto>>(users);
            return this.Ok(userDtos);
        }

        [HttpPost("update")]
        public IActionResult UpdateUsers([FromBody] IList<UserDto> users)
        {
            IList<User> userList = this.mapper.Map<IList<User>>(users);
            this.userService.UpdateRange(userList);
            return this.Ok(users.Count);
        }
    }
}