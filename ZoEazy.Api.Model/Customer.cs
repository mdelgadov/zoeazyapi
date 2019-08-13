using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ZoEazy.Api.Model
{
    public class Customer : IdentityUser, IShortHuman
    {

        [Required]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public virtual List<CustomerPhone> Phones { get; set; }
        public virtual List<CustomerAddress> Addresses { get; set; }
        public virtual List<CustomerCreditCard> CreditCards { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}