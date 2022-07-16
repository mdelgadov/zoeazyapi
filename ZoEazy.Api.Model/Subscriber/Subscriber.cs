using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.StripeEntities;

namespace ZoEazy.Api.Model.Subscriber
{

    public class Subscriber : ApplicationUser, ILongHuman, ICustomerEntity
    {
        public Subscriber()
        {
            Created = new Status(Id);
        }
        public HumanName Name { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Image is a byte array")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public Gender Gender { get; set; }
        public string Website { get; set; }
        public string PaymentSystemId { get; set; }
        [StringLength(4)]
        public string L4DSSN { get; set; }
        [NotMapped]
        public Date DateOfBirth { get; set; }
        [NotMapped]
        public Flag Suspended { get; set; }
        public List<Phone> Phones { get;  }
        public Fax Fax { get; set; }
        public Address Address { get; set; }
        public IEnumerable<CreditCard> CreditCards { get;  }
        public IEnumerable<Franchise.Franchise> Franchises { get;  }
        public Status Created { get; set; }
        public Status Updated { get; set; }
        public Status Deleted { get; set; }


        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Subscriber> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateAsync(this);         

        //        //manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    userIdentity.AddClaim(new Claim("FirstName", FirstName));
        //    userIdentity.AddClaim(new Claim("LastName", LastName));
        //    //userIdentity.AddClaim(new Claim("Address", this.Addresses.Find));
        //    //userIdentity.AddClaim(new Claim("Phone", this.Phone));
        //    //userIdentity.AddClaim(new Claim("Latitude", this.Latitude.ToString()));
        //    //userIdentity.AddClaim(new Claim("Longitude", this.Longitude.ToString()));

        //    // Add custom user claims here
        //    return userIdentity;
        //}
        //// public IEnumerable<todoItem> todoItems { get; set; }
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Subscriber> manager, string authenticationType)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
        //    // Add custom user claims here
        //    //userIdentity.AddClaim(new Claim("ShowFranchiseWelcomeScreen", ShowFranchiseWelcomeScreen.ToString()));
        //    userIdentity.AddClaim(new Claim("EmailConfirmed", EmailConfirmed.ToString()));

        //    if (FirstName != null)
        //        userIdentity.AddClaim(new Claim("FirstName", FirstName));

        //    if (LastName != null)
        //        userIdentity.AddClaim(new Claim("LastName", LastName));

        //    //if (this.Address != null)
        //    //    userIdentity.AddClaim(new Claim("Address", this.Address));
        //    //if (this.Phone != null)
        //    //    userIdentity.AddClaim(new Claim("Phone", this.Phone));
        //    //if (this.Latitude != null)
        //    //    userIdentity.AddClaim(new Claim("Latitude", this.Latitude.ToString()));
        //    //if (this.Longitude != null)
        //    //    userIdentity.AddClaim(new Claim("Longitude", this.Longitude.ToString()));

        //    return userIdentity;
        //}
    }

}