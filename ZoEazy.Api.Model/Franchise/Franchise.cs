using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Franchise

{
    public class Franchise : AuditableEntity
    {
        public Franchise(Guid user) : base(user)
        {
            CustomerType = CustomerType.Regular;
        }

        [Required]
        public CustomerType CustomerType { get; set; }
        [JsonIgnore]
        [Required]
        public Guid SubscriberId { get; set; }

        [JsonIgnore]
        [ForeignKey("SubscriberId")]
        public Subscriber.Subscriber Subscriber { get; set; }
        public IEnumerable<Phone> Phones { get; }
        public IEnumerable<Fax> Faxes { get; }
        public IEnumerable<Address> Addresses { get; }
        public IEnumerable<Branch.Branch> Branches { get; }
    }
}