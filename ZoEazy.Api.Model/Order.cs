using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{

    public class Order
    {[Key]
        public int Id { get; set; }
        public string Name { get; set; }
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
        public virtual List<OrderItem> OrderItems { get; set; }
        public int Branch_Id { get; set; }

        [JsonIgnore][ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
        
        [Required]
        public string Customer_Id { get; set; }

        [JsonIgnore][ForeignKey("Customer_Id")]
        //[Required]
        public virtual Customer Customer { get; set; }


    }
}