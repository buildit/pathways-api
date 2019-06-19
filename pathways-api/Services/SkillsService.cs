using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Design;
using pathways_api.Data;
using pathways_api.Data.Entities;
using pathways_api.Data.Mappers;
using pathways_api.Services.Interfaces;

namespace pathways_api.Services
{
    using AutoMapper;
    using Microsoft.Graph;

    public class SkillsService: ISkillsService
    {
        private DataContext context;
        private readonly IMapper mapper;

        public SkillsService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public List<UserDto> GetUsersSkills()
        {
            var users = new List<UserDto>();
            
            var activeUsers = this.context.Users.Where(x => x.IsActive).ToList(); //get all active users
            var usersSkills = this.context.UserSkills.Where(x => activeUsers.Select(y => y.Id).Contains(x.UserId)).ToList(); //get all active users skills

            foreach (var user in activeUsers)
            {
                var userSkills = usersSkills.Where(x => x.UserId == user.Id).ToList(); //get user specific skills

                var userSkillsDto = this.mapper.Map<List<UserSkillDto>>(userSkills);
                    
                var userDto = new UserDto()
                {
                    Id = user.Id,
                    UserSkills = userSkillsDto
                };

                users.Add(userDto);
            }

            return users;
        }
        
        public UserDto GetUserSkills(int userId)
        {
            var userData = this.context.Users.Where(x => x.Id == userId)?.First();
            var userSkills = this.context.UserSkills.Where(x => x.UserId == userId).ToList(); //get user skills
            
            var userSkillsDto = this.mapper.Map<List<UserSkillDto>>(userSkills);

            var userDto = new UserDto()
            {
                Id = userData.Id,
                UserSkills = userSkillsDto
            };

            return userDto;
        }
    }
}