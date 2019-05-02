using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    [Table("users")]
    public class User : IdEntity
    {
        public int Login_id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
