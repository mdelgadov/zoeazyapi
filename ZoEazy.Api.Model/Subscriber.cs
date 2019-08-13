using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.StripeEntities;
namespace ZoEazy.Api.Model
{
   
    public class Subscriber : ApplicationUser, ILongHuman, ICustomerEntity
    {
        // public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
       
        // public string LastName { get; set; }
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public Gender Gender { get; set; }
        public string Website { get; set; }

        public string PaymentSystemId { get; set; }

        [StringLength(4)]
        public string L4DSSN { get; set; }
        [NotMapped]
        public ZeDate DateOfBirth { get; set; }
        [NotMapped]
        public Flag Suspended { get; set; }
        public virtual List<SubscriberPhone> Phones { get; set; }

        public virtual SubscriberFax Fax { get; set; }
        public virtual SubscriberAddress Address { get; set; }

        public virtual List<SubscriberCreditCard> CreditCards { get; set; }
        
        public virtual List<Franchise> Franchises { get; set; }

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
        //// public virtual List<todoItem> todoItems { get; set; }
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