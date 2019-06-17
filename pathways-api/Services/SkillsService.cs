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
    public class SkillsService: ISkillsService
    {
        private DataContext context;

        public SkillsService(DataContext context)
        {
            this.context = context;
        }
        
        public List<UserDto> GetUsersSkills()
        {
            var users = new List<UserDto>();
            
            var activeUsers = this.context.Users.Where(x => x.IsActive).ToList(); //get all active users
            var usersSkills = this.context.UserSkills.Where(x => activeUsers.Select(y => y.Id).Contains(x.UserId)).ToList(); //get all active users skills

            foreach (var user in activeUsers)
            {
                var userSkills = usersSkills.Where(x => x.UserId == user.Id).ToList(); //get user specific skills

                var userSkillsDto = new List<UserSkillDto>();
                foreach (var userSkill in userSkills)
                {
                    //TODO: Use automapper
                    var skill = new UserSkillDto()
                    {
                        User = userSkill.User,
                        SkillLevel = userSkill.SkillLevel,
                        SkillType = userSkill.SkillType
                    };

                    userSkillsDto.Add(skill);
                }

                //TODO: use automapper
                var userDto = new UserDto()
                {
                    Id = user.Id,
                    UserLoginId = user.UserLoginId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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
            
            var userSkillsDto = new List<UserSkillDto>();
            foreach (var userSkill in userSkills)
            {
                //TODO: Use automapper
                var skill = new UserSkillDto()
                {
                    User = userSkill.User,
                    SkillLevel = userSkill.SkillLevel,
                    SkillType = userSkill.SkillType
                };

                userSkillsDto.Add(skill);
            }
            
            //TODO: Use automapper
            var userDto = new UserDto()
            {
                Id = userData.Id,
                UserLoginId = userData.UserLoginId,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                UserSkills = userSkillsDto
            };

            return userDto;
        }
    }
}