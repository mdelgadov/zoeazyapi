using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ZoEazy.Api.Model
{
    public class BranchOrderItem
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
        [Required]
        public int Currency_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Currency_Id")]
        public  Currency Currency { get; set; }
        public string Concept { get; set; }
        [Required]
        public LongPeriod Period_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Period_Id")]
        public  ContractPeriod Period { get; set; }
        [Required]
        public int Plan_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Plan_Id")]
        public  Plan Plan { get; set; }

    }
}