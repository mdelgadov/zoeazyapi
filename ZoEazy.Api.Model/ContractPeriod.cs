using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class ContractPeriod
    {
        [Key]
        public LongPeriod Id { get; set; }
        public int Months { get; set; }
        public int Discount { get; set; }
        // public bool Active { get; set; }
        [JsonIgnore]
        public virtual List<ContractItem> ContractItems { get; set; }
        [JsonIgnore]
        public virtual List<Plan> Plans { get; set; }
    }
}