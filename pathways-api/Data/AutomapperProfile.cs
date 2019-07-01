namespace pathways_api.Data
{
    using AutoMapper;
    using Entities;
    using Mappers;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserDto>();
            this.CreateMap<UserDto, User>();
            this.CreateMap<RoleLevelDto, RoleLevel>();
            this.CreateMap<RoleLevel, RoleLevelDto>();
            this.CreateMap<RoleTypeDto, RoleType>();
            this.CreateMap<RoleType, RoleTypeDto>();
            this.CreateMap<SkillType, SkillTypeDto>().ReverseMap();
            this.CreateMap<SkillLevel, SkillLevelDto>().ReverseMap();
            this.CreateMap<SkillTypeLevel, SkillTypeLevelDto>().ReverseMap();
            this.CreateMap<RoleLevelRule, RoleLevelRuleDto>().ReverseMap();
            this.CreateMap<UserSkill, UserSkillDto>().ReverseMap();
            this.CreateMap<UserSkilledDto, User>().ReverseMap();
            this.CreateMap<UserSkilledSkillDto, UserSkill>().ReverseMap();
        }
    }
}