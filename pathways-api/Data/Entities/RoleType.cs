using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    /// <summary>
    /// software engineer, delivery lead, creative tech, etc
    /// </summary>
    [Table("roletype", Schema = "skills")]
    public class RoleType : NamedEntity
    {
        public string Title { get; set; }
    }
}
