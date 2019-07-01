namespace pathways_api.Data.Mappers
{
    public class RoleLevelRuleExpandedDto
    {
        public RoleTypeDto RoleType { get; set; }

        public RoleLevelDto RoleLevel { get; set; }

        public SkillLevelDto SkillLevel { get; set; }

        public SkillTypeDto SkillType { get; set; }
    }
}