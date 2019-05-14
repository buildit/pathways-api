using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("rolelevels", Schema = "skills")]
    public class RoleLevel : NamedEntity
    {
        //example: associate, senior, principle
    }
}