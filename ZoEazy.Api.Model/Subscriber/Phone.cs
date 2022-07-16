using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Subscriber
{
    public class Phone : Model.Phone, ISubscriberDependent
    {
       
        [Required]
        public Guid SubscriberId { get; set; }
        [JsonIgnore]
        [ForeignKey("SubscriberId")]
        public  Subscriber Subscriber { get; set; }
    }
}