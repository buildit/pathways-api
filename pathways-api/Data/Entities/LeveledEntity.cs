namespace pathways_api.Data.Entities
{
    using pathways_common.Entities;

    public abstract class LeveledEntity : DescriptionEntity
    {
        public int Level { get; set; }
    }
}