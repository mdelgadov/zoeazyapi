using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ZoEazy.Api.Model.StripeEntities;

namespace ZoEazy.Api.Model
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
        public int? Franchise_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Franchise Franchise { get; set; }
        public int? Branch_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
        public DateTimeOffset? ValidFromUtc { get; set; }
        public DateTimeOffset? ValidToUtc { get; set; }
        //[Required]
        public LongPeriod Period_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Period_Id")]
        public virtual ContractPeriod Period { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        // public string Description { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        public decimal SetupCharge { get; set; }
        public decimal SetupDiscount { get; set; }
        [Required]
        public int Currency_Id { get; set; }
        

        [ForeignKey("Currency_Id")]
        public virtual Currency Currency { get; set; }
        
        [DefaultValue(DaysFree.zero)]
        public DaysFree DaysFree { get; set; }
        [DefaultValue(SetupDays.days)]
        public SetupDays SetupDays { get; set; }
        public virtual List<Feature> Features { get; set; }

        public int AmountInCents
        {
            get
            {
                return (int)Math.Floor(Charge * 100);
            }
        }
    }
}