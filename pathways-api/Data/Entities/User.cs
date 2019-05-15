using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("users", Schema = "admin")]
    public class User : ADUserEntity
    {
        public User()
        {
        }

        public User(string adEmail, string adName)
        {
            this.Username = adEmail;
            this.DirectoryName = adName;
        }

        public string DomoIdentifier { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}