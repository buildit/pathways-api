namespace pathways_api.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using pathways_common.Entities;
    using pathways_common.Interfaces.Entities;

    /// <summary>
    /// rules to qualify role level
    /// example: Senior, Engineer, Coding, 5
    /// </summary>
    [Table("rolelevelrule", Schema = "admin")]
    public class RoleLevelRule : AuditableEntity
    {
        public int RoleTypeId { get; set; }

        public RoleType RoleType { get; set; }

        public int RoleLevelId { get; set; }

        public RoleLevel RoleLevel { get; set; }

        public int SkillTypeId { get; set; }

        public SkillType SkillType { get; set; }

        public int SkillLevelId { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public bool? EssentialSkill { get; set; }
    }
}