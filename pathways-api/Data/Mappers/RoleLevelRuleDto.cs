using pathways_api.Data.Entities;

namespace pathways_api.Data.Mappers
{
    public class RoleLevelRuleDto
    {
        public int RoleTypeId { get; set; }

        public RoleType RoleType { get; set; }

        public int RoleLevelId { get; set; }

        public RoleLevel RoleLevel { get; set; }

        public int SkillTypeId { get; set; }

        public SkillType SkillType { get; set; }

        public int SkillLevelId { get; set; }

        public SkillLevel SkillLevel { get; set; }
    }
}