using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{

    public class Order : Delete
    {
        public float Sequence { get; set; }
        [Required]
        public bool Ordered { get; set; }
        public DateTimeOffset OrderedUtc { get; set; }
        public bool Prepped { get; set; }
        public DateTimeOffset PreppedUtc { get; set; }
        public bool Sent { get; set; }
        public DateTimeOffset SentUtc { get; set; }
        public bool Delivered { get; set; }
        public DateTimeOffset DeliveredUtc { get; set; }
        public IEnumerable<OrderItem> OrderItems { get;  }
        public int BranchId { get; set; }

        public string CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }


    }
}