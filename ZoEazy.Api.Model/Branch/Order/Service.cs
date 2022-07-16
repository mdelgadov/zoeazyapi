using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ZoEazy.Api.Model.Branch.Order
{
    public class Service : Delete, IService
    {
       [Required]
        public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        public int MonthsFree { get; set; }
        public int CurrencyId { get; set; }
        [JsonIgnore]
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        public string Concept { get; set; }

        [Required]
        public ServiceEnum ServiceId { get; set; }

        [Required]
        public int PlanId { get; set; }

        [JsonIgnore]
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        public string Stringify()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}