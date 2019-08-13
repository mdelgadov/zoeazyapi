using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class CustomerPhone : IPhone, IDeleted
    {
        public CustomerPhone()
        {
            
        }
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public int? Extension { get; set; }
        [DefaultValue(false)]
        public bool IsCell { get; set; }
        [DefaultValue(false)]
        public bool Sms { get; set; }
        public string Memo { get; set; }
        //public string Locale { get; set; }
        [Required]
        public string Customer_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }
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