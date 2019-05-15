namespace pathways_api.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using pathways_common.Entities;

    /// <summary>
    /// rules to qualify role level
    /// example: Senior, Engineer, Coding, 5
    /// </summary>
    [Table("rolelevelrule", Schema = "admin")]
    public class RoleLevelRule : IdEntity
    {
        public int RoleTypeId { get; set; }

        public RoleType RoleType { get; set; }

        public int RoleLevelId { get; set; }

        public RoleLevel RoleLevel { get; set; }

        public int SkillTypeId { get; set; }

        public SkillType SkillType { get; set; }

        public int SkillLevelId { get; set; }

        public RoleLevel SkillLevel { get; set; }
    }
}