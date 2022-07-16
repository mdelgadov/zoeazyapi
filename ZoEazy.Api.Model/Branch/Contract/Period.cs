using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model.Branch.Contract
{
    public class Period
    {
        [Key]
        public LongPeriod Id { get; set; }
        public int Months { get; set; }
        public int Discount { get; set; }
        
        [JsonIgnore]
        public IEnumerable<Item> Items { get;  }
        [JsonIgnore]
        public IEnumerable<Model.Branch.Plan> Plans { get;  }
    }
}