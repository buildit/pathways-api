using System;
using System.Collections.Generic;

namespace pathways_api.Data.Mappers
{
    public class DataSetDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        public Owner owner { get; set; }
        public DateTime dataCurrentAt { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool pdpEnabled { get; set; }
    }
    
    public class Owner
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}