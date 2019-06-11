namespace pathways_api.Data.Mappers
{
    using Entities;
    using pathways_common.Entities;

    public class UserSkillDto : AuditableEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int SkillLevelId { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public int SkillTypeId { get; set; }

        public SkillType SkillType { get; set; }
    }
}