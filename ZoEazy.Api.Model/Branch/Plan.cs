using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ZoEazy.Api.Model.StripeEntities;

namespace ZoEazy.Api.Model.Branch
{
    //public  class Plan : PlanEntityBase
    //{
    //    public Plan()
    //    {
    //        this.Features = new HashSet<Feature>();
    //    }


    //     public System.DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public System.DateTime ModifiedAt { get; set; }
    //    public string ModifiedBy { get; set; }

    //    public virtual ICollection<Feature> Features { get; set; }

    //    public string Nickname { get; set; }
    //    public int AmountInCents { get; set; }
    //    public string CurrencyCode { get; set; }

    //    public string Interval { get; set; }
    //    public int? TrialPeriodDays { get; set; }
    //    public int AmountInDollars
    //    {
    //        get
    //        {
    //            return (int)Math.Floor((decimal)this.AmountInCents / 100);
    //        }
    //    }

    //}
    public class Plan : PlanEntityBase
    {
        public Plan()
        {
        }

        [Key]
        public int Id { get; set; }
        public int? FranchiseId { get; set; }
        [JsonIgnore]
        [ForeignKey("FranchiseId")]
        public Franchise.Franchise Franchise { get; set; }
        public int? BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public DateTimeOffset? ValidFromUtc { get; set; }
        public DateTimeOffset? ValidToUtc { get; set; }
        //[Required]
        public LongPeriod PeriodId { get; set; }

        [JsonIgnore]
        [ForeignKey("PeriodId")]
        public Contract.Period Period { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        // public string Description { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        public decimal SetupCharge { get; set; }
        public decimal SetupDiscount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        
        [DefaultValue(DaysFree.zero)]
        public DaysFree DaysFree { get; set; }
        [DefaultValue(SetupDay.days)]
        public SetupDay SetupDays { get; set; }
        public IEnumerable<Feature> Features { get;  }

        public int AmountInCents
        {
            get
            {
                return (int)Math.Floor(Charge * 100);
            }
        }
    }

}