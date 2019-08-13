using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Branch_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
      
        public virtual List<ContractItem> Items { get; set; }
        [Required]
        public int Plan_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Plan_Id")]
        public virtual Plan Plan { get; set; }

        [Required]
        public int SubscriberCreditCard_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("SubscriberCreditCard_Id")]
        public virtual SubscriberCreditCard CreditCard { get; set; }

        [JsonIgnore]
        public DateTimeOffset CreatedUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset ActiveUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset CancelledUtc { get; set; }
        [JsonIgnore]
        public DateTimeOffset ExpiredUtc { get; set; }

        [DefaultValue(false)]
        private ContractStatus _Status;
        public ContractStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                if (_Status == ContractStatus.Active) ActiveUtc = DateTimeOffset.Now;
                if (_Status == ContractStatus.Cancelled) CancelledUtc = DateTimeOffset.Now;
                if (_Status == ContractStatus.Created) CreatedUtc = DateTimeOffset.Now;
                if (_Status == ContractStatus.Expired) ExpiredUtc = DateTimeOffset.Now;
            }
        }

        public Contract()
        {
            Status = ContractStatus.Created;
        }
    }
}