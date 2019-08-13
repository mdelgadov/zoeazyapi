using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace ZoEazy.Api.Model
{
    public class CustomerCreditCard : IPaymentMethod, ICreditCard
    {
        protected CustomerCreditCard()
        {
            Status = CreditCardStatus.inactive;
        }
        [Key]
        public int Id { get; set; }
        public int Sequence { get; set; }
        private CreditCardStatus _Status { get; set; }
        public CreditCardStatus? Status
        {
            get
            {
                if (_Status != CreditCardStatus.expired && IsExpired()) { return CreditCardStatus.expired; }
                return _Status;
            }
            set
            {
                if (value == null) value = CreditCardStatus.inactive;
                _Status = (CreditCardStatus)value;
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
            if (ValidThruYear < 2018 || ValidThruMonth > 12 || ValidThruMonth < 0) expired = true;
            if (ValidThruYear < n.Year) expired = true;
            if (ValidThruYear == n.Year && ValidThruMonth < n.Month) expired = true;
            else
            {
                var firstMoment = new DateTime(ValidThruYear, ValidThruMonth, DateTime.DaysInMonth(ValidThruYear, ValidThruMonth)).AddDays(2);
                expired = (DateTime.Now - firstMoment).TotalMilliseconds > 0;
            }
            if (expired && Status != CreditCardStatus.expired)
            {
                Status = CreditCardStatus.expired;
            }
            return expired;
        }
        public string CCV { get; set; }
        public int ValidThruYear { get; set; }
        public int ValidThruMonth { get; set; }
        [JsonIgnore]
        public DateTimeOffset ActivatedUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset ExpiredUtc { get; set; }
        [Required]
        public CreditCardEnum CreditCardBrand_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardBrand_Id")]
        public CreditCardBrand Brand { get; set; }
        public string TokenId { get; set; }

        [Required]
        public string Number { get; set; }
        public string Name { get; set; }

        [Required]
        [MaxLength(5), MinLength(5)]
        public string PostalCode { get; set; }
        [Required]
        public string Customer_Id { get; set; }
        [JsonIgnore][ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}