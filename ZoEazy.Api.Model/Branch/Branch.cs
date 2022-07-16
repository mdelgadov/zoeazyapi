using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.ViewModels;

namespace ZoEazy.Api.Model.Branch
{
    public class Branch : AuditableEntity
    {
        public Branch(Guid user) : base(user)
        {
            
            CustomerType = CustomerType.Regular;
            BankAccount.BankAccountType = BankAccountType.Checking;
            Config.Unit = (Length)ConfigDefault.RadiusUnit;
            Config.Radius = (double)ConfigDefault.Radius;
        }
        
        [JsonIgnore]
        public CustomerType CustomerType { get; set; }
        [JsonIgnore]
        public string StripeCustomerId { get; set; }
        [Required]
        public int FranchiseId { get; set; }
        [JsonIgnore]
        [ForeignKey("FranchiseId")]
        public virtual Franchise.Franchise Franchise { get; set; }
        public IEnumerable<Cuisine> Cuisines { get;  }
        public IEnumerable<Menu> Menus { get;  }
        public IEnumerable<Offer> Offers { get; }
        public Status Proposed { get; set; }
        public Status Executed { get; set; }
        public Status Active { get; set; }
        public  Branch ToBranch(GeoViewModel v)
        {
            if (v == null) return null;
           
            return new Branch(Created.ByUser)
            {
                Id = v.Id,
                Config = new Config { Zoom = v.Zoom, Radius = v.Radius, Unit = v.Unit },
                DeliveryArea = v.DeliveryArea,
                PostalCodes = v.PostalCodes
            };
        }

        public DeliveryArea DeliveryArea { get; set; }
        public IEnumerable<Contract.Contract> Contracts { get;  }
        public IEnumerable<Order.Order> Orders { get;  }
        public System.Uri Url { get; set; }
        [JsonIgnore]
        public string Secret { get; set; }
        public IEnumerable<Phone> Phones { get;  }
        public IEnumerable<Fax> Faxes { get;  }
        public Address Address { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public IEnumerable<PostalCode> PostalCodes { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        public IEnumerable<Schedule> Schedules { get;  }
        public Config Config { get; set; }
        public BankAccount BankAccount { get;  }



    }
}

