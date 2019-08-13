using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ZoEazy.Api.Model
{
    public class BranchOrderService
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BranchOrder_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchOrder_Id")]
        public virtual BranchOrder BranchOrder { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        public int Currency_Id { get; set; }
        public int MonthsFree { get; set; }

        [JsonIgnore]
        [ForeignKey("Currency_Id")]
        public virtual Currency Currency { get; set; }
        public string Concept { get; set; }
        public string Stringify()
        {
            return JsonConvert.SerializeObject(this);
        }
        [Required]
        public ServiceEnum Service_Id { get; set; }

        [Required]
        public int Plan_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Plan_Id")]
        public virtual Plan Plan { get; set; }
    }
}