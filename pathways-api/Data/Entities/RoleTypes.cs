using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace pathways_api.Data.Entities
{
    [Table("rolestypes")]
    public class RoleType : NamedEntity
    {
       //example: software engineer, delivery lead, creative tech, etc
    }
}
