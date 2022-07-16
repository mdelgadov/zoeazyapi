using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ZoEazy.Api.Model
{
    public class Customer : Delete, IHuman
    {

        [Required]
        public new HumanName Name { get; set; }

        public Gender Gender { get; set; }

        public IEnumerable<CustomerPhone> Phones { get;  }
        public IEnumerable<CustomerAddress> Addresses { get;  }
        public IEnumerable<CustomerCreditCard> CreditCards { get;  }
        public IEnumerable<Favorite> Favorites { get;  }
        public IEnumerable<Order> Orders { get;  }
    }
}