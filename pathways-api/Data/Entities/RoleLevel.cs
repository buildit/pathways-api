using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    /// <summary>
    /// associate, senior, principle
    /// </summary>
    [Table("rolelevel", Schema = "skills")]
    public class RoleLevel : DescriptionEntity
    {
        public int Level { get; set; }
    }
}