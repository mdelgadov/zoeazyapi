using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class SubscriberFax : IFax
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        [Required]
        public Guid Subscriber_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Subscriber_Id")]
        public virtual Subscriber Subscriber { get; set; }
        //public string Locale { get; set; }
        public bool Deleted { get; set; }
        [JsonIgnore]
        public DateTimeOffset DeletedUtc { get; set; }
    }
}