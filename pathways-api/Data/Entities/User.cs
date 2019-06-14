using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("users", Schema = "admin")]
    public class User : PathwaysUser
    {
        public User()
        {
        }

        public User(string username, string organizationId, string directoryName)
            : base(username, organizationId, directoryName)
        {
        }

        public string DomoIdentifier { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}