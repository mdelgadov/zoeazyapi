using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Branch.Contract
{
    public class Contract : AuditableEntity
    {

        public Contract(Guid user) : base(user) { }

        [Required]
        public int BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public IEnumerable<Item> Items { get;  }
        [Required]
        public int PlanId { get; set; }
        [JsonIgnore]
        [ForeignKey("PlanId")]
        public  Plan Plan { get; set; }

        [Required]
        public int CreditCardId { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardId")]
        public Subscriber.CreditCard CreditCard { get; set; }

        [JsonIgnore]
        public Status Active { get; set; }
        [JsonIgnore]
        public Status Cancelled { get; set; }
        [JsonIgnore]
        public Status Expired { get; set; }

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
                Active = new Status(Created.ByUser, _Status == ContractStatus.Cancelled);
                Cancelled = new Status(Created.ByUser, _Status == ContractStatus.Cancelled);
                Created = new Status(Created.ByUser, _Status == ContractStatus.Created);
                Expired = new Status(Created.ByUser, _Status == ContractStatus.Expired);
            }
        }

       
    }
}