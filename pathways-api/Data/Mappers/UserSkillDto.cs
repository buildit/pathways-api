using pathways_api.Data.Entities;

namespace pathways_api.Data.Mappers
{
    public class UserSkillDto
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillLevelId { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public int SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }
    }
}