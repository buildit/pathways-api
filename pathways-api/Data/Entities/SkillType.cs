using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace pathways_api.Data.Entities
{
    [Table("skilltypes")]
    public class SkillType : NamedEntity
    {
        //example: Coding, Leadership, Mentoring, etc
    }
}
