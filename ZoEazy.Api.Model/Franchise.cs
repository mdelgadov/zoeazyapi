using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Franchise : ClientChangeTracker, IInstitution
    {
        public Franchise(){
            CustomerType = CustomerType.Regular;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public CustomerType CustomerType { get; set; }
        [JsonIgnore]
        [Required]
        public Guid Subscriber_Id { get; set; }
        
        [JsonIgnore]
        [ForeignKey("Subscriber_Id")]
        public virtual Subscriber Subscriber { get; set; }
        
        public virtual List<FranchisePhone> Phones { get; set; }

        public virtual List<FranchiseFax> Faxes { get; set; }
        public virtual List<FranchiseAddress> Addresses { get; set; }
        public virtual List<Branch> Branches { get; set; }
    }
}