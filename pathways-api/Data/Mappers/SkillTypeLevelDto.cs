namespace pathways_api.Data.Mappers
{
    using pathways_common.Entities;

    public class SkillTypeLevelDto : IdEntity
    {
        public int SkillTypeId { get; set; }

        public int SkillLevelId { get; set; }

        public string Description { get; set; }
    }
}