namespace pathways_api.Data.Entities
{
    public abstract class NamedEntity : IdEntity
    {
        public string Name { get; set; }
    }
}