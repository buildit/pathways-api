using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    [Table("roles")]
    public class Role : IdEntity
    {
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public int RoleLevelId { get; set; }
        public RoleLevel RoleLevel { get; set; }
        
    }
}
