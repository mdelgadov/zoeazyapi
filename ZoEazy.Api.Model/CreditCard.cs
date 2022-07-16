using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace ZoEazy.Api.Model
{
    public abstract class CreditCard : ZoEazy.Api.Model.Delete, IPaymentMethod, ICreditCard
    {
        public CreditCard()
        {
            Status = CreditCardStatus.inactive;
        }
       

        [JsonIgnore]
        public int Sequence { get; set; }
        private CreditCardStatus _Status { get; set; }
        public CreditCardStatus Status
        {
            get
            {
                if (_Status == CreditCardStatus.expired || IsExpired()) { return CreditCardStatus.expired; }
                return _Status;
            }
            set
            {
                _Status = (CreditCardStatus)value;
                if (_Status == CreditCardStatus.active) ActivatedUtc = DateTimeOffset.Now;
                if (_Status == CreditCardStatus.expired) ExpiredUtc = DateTimeOffset.Now;
            }
        }
        private bool IsExpired()
        {
            return ValidThru.Expired();
            
        }

        [JsonIgnore]
        public DateTimeOffset ActivatedUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset ExpiredUtc { get; set; }
        public string CCV { get; set; }
        public ValidThru ValidThru { get; set; }
        [Required]
        public CreditCardEnum CreditCardBrandId { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardBrandId")]
        public CreditCardBrand Brand { get; set; }
        public string TokenId { get; set; }
        [Required]
        private string _Number;
        public string Number
        {
            get
            {
                return _Number.Substring(_Number.Length -4);
            }
            set
            {
                _Number = value;
            }
        }
    


        [Required]
        [MaxLength(5), MinLength(5)]
        public string PostalCode { get; set; }
    }
    
}