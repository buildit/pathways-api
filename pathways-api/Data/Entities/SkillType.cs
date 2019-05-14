using System.ComponentModel.DataAnnotations.Schema;
namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    [Table("skilltypes", Schema = "skills")]
    public class SkillType : NamedEntity
    {
        //example: Coding, Leadership, Mentoring, etc
    }
}
