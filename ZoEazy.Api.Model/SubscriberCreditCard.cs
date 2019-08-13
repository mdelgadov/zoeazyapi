using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace ZoEazy.Api.Model
{
    public class SubscriberCreditCard :IPaymentMethod, ICreditCard, IDeleted, IId
    {
        public SubscriberCreditCard()
        {
            Status = CreditCardStatus.inactive;
        }
       
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
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
            if (ValidThruYear < n.Year) expired = true;
            if (ValidThruYear == n.Year && (ValidThruMonth +1) < n.Month) expired = true;
            else
            {
                var firstMoment = new DateTime(ValidThruYear, ValidThruMonth + 1, DateTime.DaysInMonth(ValidThruYear, ValidThruMonth +1)).AddDays(2);
                expired = (DateTime.Now - firstMoment).TotalMilliseconds > 0;
            }
            if (expired && Status != CreditCardStatus.expired) {
                Status = CreditCardStatus.expired;
            }
            return expired;
        }

        [JsonIgnore]
        public DateTimeOffset ActivatedUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset ExpiredUtc { get; set; }
        public string CCV { get; set; }
        public int ValidThruYear { get; set; }
        public int ValidThruMonth { get; set; }
        [Required]
        public CreditCardEnum CreditCardBrand_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardBrand_Id")]
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
        public string Name { get; set; }

        [Required]
        [MaxLength(5), MinLength(5)]
        public string PostalCode { get; set; }
        [JsonIgnore]
        [Required]
        public Guid Subscriber_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Subscriber_Id")]
        public virtual Subscriber Subscriber { get; set; }
        [JsonIgnore]
        public virtual List<BranchOrder> Orders { get; set; }
        [JsonIgnore]
        public virtual List<Contract> Contracts { get; set; }
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