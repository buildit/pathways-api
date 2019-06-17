namespace pathways_api.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Working, expert, aware, practitioner
    /// </summary>
    [Table("skilllevel", Schema = "skills")]
    public class SkillLevel : LeveledEntity
    {
    }
}