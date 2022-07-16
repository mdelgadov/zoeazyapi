using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Model
{
    public interface IHumanName
    {
        string First { get; set; }
        string Middle { get; set; }
        string Last { get; set; }
    }

    public interface IAddress
    {

        [Required]
        string Street { get; set; }
        string Apartment { get; set; }
        [Required]
        string City { get; set; }
        [Required]
        [MaxLength(5), MinLength(5)]
        string PostalCode { get; set; }

        double Latitude { get; set; }

        double Longitude { get; set; }
        //[TsIgnore]
        // public DbGeography Position { get; set; }

        int StateId { get; set; }

        [JsonIgnore]
        [ForeignKey("StateId")]
        State State { get; set; }



    }
    public interface IBankAccount
    {
        [Required]
        BankAccountType BankAccountType { get; set; }
        [Required]
        string Routing { get; set; }
        [Required]
        string Account { get; set; }

    }

    public interface IConfig
    {
        double? Radius { get; set; }
        
        double? Zoom { get; set; }
        IEnumerable<WebsiteName> Websites { get;  }
        InitialWebsiteState State { get; set; }

        Redirection Redirection { get; set; }
        string AppName { get; set; }
    }

    public interface ICreditCard
    {
        string CCV { get; set; }
        ValidThru ValidThru { get; set; }
        CreditCardBrand Brand { get; set; }
        string Number { get; set; }
        string Name { get; set; }
        string TokenId { get; set; }
        string PostalCode { get; set; }
    }
    public interface IDeleted
    {
        Status Deleted { get; set; }
    }
    public interface IDish
    {

        [Required]
        string Name { get; set; }
        string Description { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
        byte[] Image { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        string ImageSource { get; set; }
        float Sequence { get; set; }

    }
    public interface IHuman
    {
        [Required]
        HumanName Name { get; set; }
        Gender Gender { get; set; }

    }
    public interface IId
    {
        [Key]
        int Id { get; set; }
         
    }
    public interface IThing
    {
        [Required]
        string Name { get; set; }

    }
    public interface ILongHuman : IHuman
    {


#pragma warning disable CA1819 // Properties should not return arrays
        byte[] Image { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        string ImageSource { get; set; }

    }
    public interface IMetaPhone
    {
        string Number { get; set; } //too long for standard int
        //string Locale { get; set; }
    }
    public interface IOrder
    {
        [Key]
        int Id { get; set; }
        IEnumerable<Branch.Order.Item> Items { get;  }

        [Required]
        int BranchId { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchId")]
        Branch.Branch Branch { get; set; }
        [Required]
        int CreditCardId { get; set; }

        [JsonIgnore]
        [ForeignKey("CreditCardId")]
        CreditCard CreditCard { get; set; }


        bool Proposed { get; set; }
        [JsonIgnore]
        DateTimeOffset ProposedUtc { get; set; }

        bool Executed { get; set; }
        [JsonIgnore]
        DateTimeOffset ExecutedUtc { get; set; }

        string Stringify();
    }
    interface ISubscriberDependent
    {
        Guid SubscriberId { get; set; }
        Subscriber.Subscriber Subscriber { get; set; }
    }
    public interface IPaymentMethod 
    {
        int Sequence { get; set; }
        CreditCardStatus Status { get; set; }
    }
    public interface IPhone
    {

        int? Extension { get; set; }

        string Memo { get; set; }
        //string Locale { get; set; }
    }
    public interface IPredefinedOrderItem
    {
        Branch.Branch Branch { get; set; }
        int? BranchId { get; set; }
        decimal Charge { get; set; }
        string Concept { get; set; }
        Model.Franchise.Franchise Franchise { get; set; }
        int? FranchiseId { get; set; }
        int Id { get; set; }
    }
    public interface IPredefinedSchedule
    {
        PredefinedDay Dow { get; set; }
        ServiceStatus? Service { get; set; }
        Hour? OpensHour { get; set; }
        DayOfMonth? Day { get; set; }
        Month? Month { get; set; }
        int? Year { get; set; }
        Quarter? OpensMinute { get; set; }
        Hour? ClosesHour { get; set; }
        Quarter? ClosesMinute { get; set; }
        string Name { get; set; }
        Boolean? Disable { get; set; }
        Boolean? IsOptional { get; set; }
        Boolean? CloseOfTheNextDay { get; set; }
    }
    public interface IPresentation
    {
        string Size { get; set; }
        [Required]
        decimal Price { get; set; }

    }
    public interface IService
    {
        decimal Charge { get; set; }

    }
    public interface ISetupOrder : IOrder
    {
        [Required]
        int ServiceId { get; set; }

        [JsonIgnore]
        [ForeignKey("ServiceId")]
        Service SetupService { get; set; }
    }
    public interface ISetupService
    {
        decimal SetupCharge { get; set; }
    }
    public interface IWebsiteName
    {
        [Required]
        int BranchId { get; set; }
        string Suffix { get; set; }
        string Domain { get; set; }
    }
}


