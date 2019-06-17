namespace pathways_api.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using pathways_common.Entities;

    /// <summary>
    /// "description": "Evaluates delivery and recruitment parties and seek innovation through technology and human approach.
    /// </summary>
    [Table("skilltypelevel", Schema = "skills")]
    public class SkillTypeLevel : IdEntity
    {
        public int SkillTypeId { get; set; }

        public SkillType SkillType { get; set; }

        public int SkillLevelId { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public string Description { get; set; }
    }
}