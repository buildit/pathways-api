namespace pathways_api.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// associate, senior, principle
    /// </summary>
    [Table("rolelevel", Schema = "skills")]
    public class RoleLevel : LeveledEntity
    {
    }
}