using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    [Table("userlogins")]
    public class UserLogin: IdEntity
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool? Deactivated { get; set; }
    }
}
