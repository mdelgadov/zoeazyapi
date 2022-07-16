using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZoEazy.Api.Model.Branch;
using ZoEazy.Api.Model.Subscriber;

namespace ZoEazy.Api.Model.ViewModels
{
    public class FranchiseeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public FranchiseViewModel Franchise { get; set; }
        public AddressViewModel Address { get; set; }
        public PhoneViewModel Phone { get; set; }
        public HumanName Name { get; set; }

    }
    public class FranchiseViewModel
    {
        public string Name { get; set; }
    }
    public class AddressViewModel
    {
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int StateId { get; set; }
    }
    public class PhoneViewModel
    {
        public string Number { get; set; }
    }
    public class PostalCodeViewModel
    {
        public string Code { get; set; }
    }
    public class BaseBranchViewModel
    {
        public int Id { get; set; }
        [Required]
        public int BranchId { get; set; }
        public bool Deleted { get; set; }
    }
    public class BranchDetailViewModel
    {

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        // public CustomerType CustomerType { get; set; }
        public int FranchiseId { get; set; }

        //public CuisineViewModel[] Cuisines { get; set; }
        public bool? Proposed { get; set; }

        public IEnumerable<BranchPhoneViewModel> Phones { get;  }
        public IEnumerable<BranchFaxViewModel> Faxes { get;  }
        public IEnumerable<BranchAddressViewModel> Addresses { get;  }
        // public BranchPostalCodeViewModel[] PostalCodes { get; set; }
        ////--------------- iconfig
        public IEnumerable<WebsiteNameViewModel> Websites { get;  }

        public double? Radius { get; set; }
        public Length? Unit { get; set; }
        public double? Zoom { get; set; }
        //---------------- bank account
        [Required]
        public BankAccountType BankAccountType { get; set; }
        [StringLength(9), Required]
        public string Routing { get; set; }
        public string RoutingJson { get; set; }
        // public string  Hint { get; set; }

        [StringLength(8)]
        public string Account { get; set; }
    }
    public class BranchPhoneViewModel : BaseBranchViewModel
    {
        public bool AndFax { get; set; }

    }
    public class BranchFaxViewModel : BaseBranchViewModel
    {
        public bool AndPhone { get; set; }
    }
    public class BranchAddressViewModel : BaseBranchViewModel
    {
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public Int32 Latitude { get; set; }
        public Int32 Longitude { get; set; }
        public IEnumerable<GeoViewModel> Geos { get;  }
    }
    public class GeoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double Zoom { get; set; }
        [Required]
        public double Radius { get; set; }
        [Required]
        public Length Unit { get; set; }
        [Required]
        public DeliveryArea DeliveryArea { get; set; }
        [Required]
        public IEnumerable<PostalCode> PostalCodes { get;  }
    }
    public class ScheduleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public IEnumerable<Schedule> Schedules { get;  }
    }
    public class OrderViewModel
    {
        [Required]
        public CreditCard CreditCard { get; set; }
        [Required]
        public Order Order { get; set; }
    }
    public class WebsiteNameViewModel : BaseBranchViewModel
    {
        public string Suffix { get; set; }
        public string Domain { get; set; }
    }
    public class CuisineViewModel : BaseBranchViewModel
    {
        public string Name { get; set; }
    }
}
