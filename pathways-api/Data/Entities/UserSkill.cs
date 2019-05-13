using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    [Table("userskills")]
    public class UserSkill
    {    
        //Self assessed skills
        //example: User, Coding, 5
        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillLevelId { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public int SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }
    }
}