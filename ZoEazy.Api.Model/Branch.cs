using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.ViewModels;

namespace ZoEazy.Api.Model
{

    public class Branch : IInstitution, IConfig, IBankAccount, IDeleted, IId
    {
        public Branch()
        {
            CustomerType = CustomerType.Regular;
            Proposed = false;
            Executed = false;
            Active = false;

            BankAccountType = BankAccountType.Checking;
            Unit = (Lengths)ConfigDefaults.Radius;
            Radius = (double)ConfigDefaults.Radius;

        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public CustomerType CustomerType { get; set; }
        [JsonIgnore]
        public string StripeCustomerId { get; set; }
        [Required]
        public int Franchise_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Franchise_Id")]
        public virtual Franchise Franchise { get; set; }
        public virtual List<Cuisine> Cuisines { get; set; }
        public virtual List<Menu> Menus { get; set; }
        public virtual List<Offer> Offers { get; set; }
        private bool _Proposed;
        public bool? Proposed
        {
            get
            {
                return _Proposed;
            }
            set
            {

                _Proposed = (value == null || value == false) ? false : true;
                if (_Proposed) ProposedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset ProposedUtc { get; set; }
        private bool _Executed;
        public bool? Executed
        {
            get
            {
                return _Executed;
            }
            set
            {

                _Executed = (value == null || value == false) ? false : true;
                if (_Executed) ProposedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset ExecutedUtc { get; set; }

        public static explicit operator Branch(GeoViewModel v)
        {
            return new Branch
            {
                Id = v.Id,
                Zoom = v.Zoom,
                Radius = v.Radius,
                Unit = v.Unit,
                DeliveryArea = v.DeliveryArea,
                PostalCodes = v.PostalCodes
            };
        }

        public bool _Active;
        public bool? Active
        {
            get
            {
                return _Active;
            }
            set
            {

                _Active = (value == null || value == false) ? false : true;
                if (_Active) ProposedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset ActiveUtc { get; set; }
        public DeliveryArea DeliveryArea { get; set; }

        public virtual List<Contract> Contracts { get; set; }

        public virtual List<BranchOrder> Orders { get; set; }
        public string Url { get; set; }

        [JsonIgnore]
        public string Secret { get; set; }

        public  List<BranchPhone> Phones { get; set; }
        public  List<BranchFax> Faxes { get; set; }
        public  BranchAddress Address { get; set; }
        public  List<PostalCode> PostalCodes { get; set; }
        public  List<Schedule> Schedules { get; set; }
        //--------------- iconfig
        public List<WebsiteName> Websites { get; set; }
        [JsonIgnore]
        public InitialWebsiteState State { get; set; }
        [JsonIgnore]
        public Redirection Redirection { get; set; }
        [JsonIgnore]
        public string AppName { get; set; }

        public double? Radius { get; set; }
        public Lengths? Unit { get; set; }
        public double? Zoom { get; set; }
        //---------------- bank account
        [Required]
        public BankAccountType BankAccountType { get; set; }
        [StringLength(9)]
        public string Routing { get; set; }
        public string RoutingJson { get; set; }
        [StringLength(8)]
        public string Account { get; set; }
        // -------------------- Deleted
        [DefaultValue(false)]
        private bool _Deleted;
        public bool? Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                if (value == null) value = false;
                _Deleted = (bool)value;
                if (_Deleted) DeletedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset DeletedUtc { get; set; }


    }
}

