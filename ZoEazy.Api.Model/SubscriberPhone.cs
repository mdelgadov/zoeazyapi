using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class SubscriberPhone : IPhone, IDeleted
    {
       
        public SubscriberPhone()
        {
            IsCell = false;
            Sms = false;
        }
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public int? Extension { get; set; }
        private bool IsCell { get; set; }
        private bool Sms { get; set; }
        public string Memo { get; set; }
        //public string Locale { get; set; }
        [Required]
        public Guid Subscriber_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Subscriber_Id")]
        public virtual Subscriber Subscriber { get; set; }
        [DefaultValue(false)]
        private bool _Deleted;
        public bool? Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                if (value == null) value = false;
                _Deleted = (bool)value;
                if (_Deleted) DeletedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset DeletedUtc { get; set; }
    }
}