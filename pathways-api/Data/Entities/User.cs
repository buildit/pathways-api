using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("users", Schema = "admin")]
    public class User : NamedEntity
    {
        public string Email { get; set; }

        public string DomoIdentifier { get; set; }
        
        public ICollection<UserSkill> UserSkills { get; set; }
    }
}