namespace pathways_api.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Data.Entities;
    using Data.Mappers;
    using Interfaces;

    public class SkillsService : ISkillsService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public SkillsService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public UserDto GetUserSkills(int userId)
        {
            User userData = this.context.Users.Where(x => x.Id == userId)?.First();
            List<UserSkill> userSkills = this.context.UserSkills.Where(x => x.UserId == userId).ToList(); //get user skills

            List<UserSkillDto> userSkillsDto = this.mapper.Map<List<UserSkillDto>>(userSkills);

            UserDto userDto = new UserDto
            {
                Id = userData.Id,
                UserSkills = userSkillsDto
            };

            return userDto;
        }
    }
}