using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Model.Subscriber
{
    public class CreditCard : Model.CreditCard
    {
        [JsonIgnore]
        [Required]
        public Guid SubscriberId { get; set; }
        [JsonIgnore]
        [ForeignKey("SubscriberId")]
        public  Subscriber Subscriber { get; set; }
        [JsonIgnore]
        public  IEnumerable<Branch.Order.Order> Orders { get; set; }
        [JsonIgnore]
        public  IEnumerable<Branch.Contract.Contract> Contracts { get; set; }

    }
}