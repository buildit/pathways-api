using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("skilllevel", Schema = "skills")]
    public class SkillLevel : NamedEntity
    {
    }
}