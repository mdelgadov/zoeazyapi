using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class Phone : IPhone, IDeleted {

        public Phone()
        {
            IsCell = false;
            Sms = false;
            AndFax = false;
        }

        
        public string Number { get; set; }
        public int? Extension { get; set; }
        private bool IsCell { get; set; }
        private bool Sms { get; set; }
        public string Memo { get; set; }
        //public string Locale { get; set; }
        public bool AndFax { get; set; }
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