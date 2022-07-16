using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace ZoEazy.Api.Model
{
    public class CustomerCreditCard : Delete, IPaymentMethod, ICreditCard
    {
        protected CustomerCreditCard()
        {
            Status = CreditCardStatus.inactive;
        }
        public int Sequence { get; set; }
        private CreditCardStatus _Status { get; set; }
        public CreditCardStatus Status
        {
            get
            {
                if (_Status != CreditCardStatus.expired && IsExpired()) { return CreditCardStatus.expired; }
                return _Status;
            }
            set
            {
                //if (value == null) value = CreditCardStatus.inactive;
                _Status = value;
                if (_Status == CreditCardStatus.active) ActivatedUtc = DateTimeOffset.Now;
                if (_Status == CreditCardStatus.expired) ExpiredUtc = DateTimeOffset.Now;
            }
        }
        // IsExpired works 99% percent of the cases
        // fringe case: if it's about to expire the client is in a time zone where hasn't expired yet...
        // that explains why to add two days at the first moment and not one...
        // two days has expired around the globe...
        // the client should also check the small pickens difference in hours...
        private bool IsExpired()
        {
            var n = DateTime.Now;
            var expired = false;
            if ((ValidThru.Year < 2018 || (int)ValidThru.Month > 12 || ValidThru.Month < 0) ||
             (ValidThru.Year < n.Year) ||
             (ValidThru.Year == n.Year && (int)ValidThru.Month < n.Month))
            {
                expired = true;
            }
            else
            {
                var firstMoment = new DateTime(ValidThru.Year, (int)ValidThru.Month, DateTime.DaysInMonth(ValidThru.Year, (int)ValidThru.Month)).AddDays(2);
                expired = (DateTime.Now - firstMoment).TotalMilliseconds > 0;
            }
            if (expired && Status != CreditCardStatus.expired)
            {
                Status = CreditCardStatus.expired;
            }
            return expired;
        }
        public string CCV { get; set; }
        public ValidThru ValidThru { get; set; }
        [JsonIgnore]
        public DateTimeOffset ActivatedUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset ExpiredUtc { get; set; }
        [Required]
        public CreditCardEnum CreditCardBrandId { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardBrandId")]
        public CreditCardBrand Brand { get; set; }
        public string TokenId { get; set; }

        [Required]
        public string Number { get; set; }
        [Required]
        [MaxLength(5), MinLength(5)]
        public string PostalCode { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [JsonIgnore]
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public IEnumerable<Order> Orders { get; }
    }
}