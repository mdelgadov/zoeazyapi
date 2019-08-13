using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System;

namespace ZoEazy.Api.Model
{

    public class BranchOrder 
    {
        [Key]
        public int Id { get; set; }
        public virtual List<BranchOrderService> Services { get; set; }
        
        public virtual BranchOrderItem Item { get; set; }
        [Required]
        public int Branch_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
        [Required]
        public int SubscriberCreditCard_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("SubscriberCreditCard_Id")]
        public virtual SubscriberCreditCard CreditCard { get; set; }
        
        public bool Proposed { get; set; }
        [JsonIgnore]
        public DateTimeOffset ProposedUtc { get; set; }

        public bool Executed { get; set; }
        [JsonIgnore]
        public DateTimeOffset ExecutedUtc { get; set; }
        public bool Cancelled { get; set; }
        [JsonIgnore]
        public DateTimeOffset CancelledUtc { get; set; }
        public string Stringify()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
}