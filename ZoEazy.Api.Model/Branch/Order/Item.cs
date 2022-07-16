using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ZoEazy.Api.Model.Branch.Order
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [JsonIgnore]
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        public string Concept { get; set; }
        [Required]
        public LongPeriod PeriodId { get; set; }

        [JsonIgnore]
        [ForeignKey("PeriodId")]
        public Model.Branch.Contract.Period Period { get; set; }
        [Required]
        public int PlanId { get; set; }

        [JsonIgnore]
        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

    }
}