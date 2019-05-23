namespace pathways_api.Data.Mappers
{
    public class DataSetRequestDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long rows { get; set; }
        public long columns { get; set; }
        public Schema schema = new Schema();
       // public Owner owner { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}