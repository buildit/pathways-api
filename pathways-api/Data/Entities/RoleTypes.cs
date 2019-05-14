using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("rolestypes", Schema = "skills")]
    public class RoleType : NamedEntity
    {
       //example: software engineer, delivery lead, creative tech, etc
    }
}
