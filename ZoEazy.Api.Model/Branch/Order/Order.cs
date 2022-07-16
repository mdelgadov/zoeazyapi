using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System;

namespace ZoEazy.Api.Model.Branch.Order
{

    public class Order : Delete
    {
        public IEnumerable<Service> Services { get;  }

        public Item Item { get; set; }
        [Required]
        public int BranchId { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        [Required]
        public int CreditCardId { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardId")]
        public Subscriber.CreditCard CreditCard { get; set; }
        public Status Proposed { get; set; }
        public Status Executed { get; set; }
        public Status Cancelled { get; set; }
        public string Stringify()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}