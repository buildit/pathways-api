using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    [Table("users")]
    public class User : IdEntity
    {
        public int UserLoginId { get; set; }
        public UserLogin UserLogin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}
