using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
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

        int? State_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("State_Id")]
        State State { get; set; }



    }
    public interface IBankAccount
    {
        [Required]
        BankAccountType BankAccountType { get; set; }

        string Routing { get; set; }

        string Account { get; set; }

    }
    public interface IConfig
    {
        double? Radius { get; set; }
        double? Zoom { get; set; }
        List<WebsiteName> Websites { get; set; }
        InitialWebsiteState State { get; set; }

        Redirection Redirection { get; set; }
        string AppName { get; set; }
    }
    public interface IContractItem
    {
        Plan Plan { get; set; }
        int Plan_Id { get; set; }
        Contract Contract { get; set; }
        int Contract_Id { get; set; }
        int Id { get; set; }
    }
    public interface ICreditCard
    {
        string CCV { get; set; }
        int ValidThruYear { get; set; }
        int ValidThruMonth { get; set; }
        CreditCardBrand Brand { get; set; }
        string Number { get; set; }
        string Name { get; set; }
        string TokenId { get; set; }
        string PostalCode { get; set; }
    }
    public interface IDeleted
    {
        bool? Deleted { get; set; }
        DateTimeOffset DeletedUtc { get; set; }
    }
    public interface IDish
    {

        [Required]
        string Name { get; set; }
        string Description { get; set; }

        byte[] Image { get; set; }
        string ImageSource { get; set; }
        float Sequence { get; set; }

    }
    public interface IFax : IMetaPhone
    {
        [Key]
        int Id { get; set; }
    }
    public interface IHuman
    {
        Gender Gender { get; set; }

    }
    public interface IId
    {
        int Id { get; set; }
    }
    public interface IInstitution
    {
        [Required]
        string Name { get; set; }

    }
    public interface ILongHuman : IHuman
    {
        [Required]
        string FirstName { get; set; }

        string MiddleName { get; set; }
        [Required]
        string LastName { get; set; }
        byte[] Image { get; set; }
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
        List<BranchOrderItem> Items { get; set; }

        [Required]
        int Branch_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        Branch Branch { get; set; }
        [Required]
        int SubscriberCreditCard_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("SubscriberCreditCard_Id")]
        SubscriberCreditCard CreditCard { get; set; }


        bool Proposed { get; set; }
        [JsonIgnore]
        DateTimeOffset ProposedUtc { get; set; }

        bool Executed { get; set; }
        [JsonIgnore]
        DateTimeOffset ExecutedUtc { get; set; }

        string Stringify();
    }
    public interface IPaymentMethod
    {
        [Key]
        int Id { get; set; }
        int Sequence { get; set; }
        CreditCardStatus? Status { get; set; }
    }
    public interface IPhone
    {

        int? Extension { get; set; }

        string Memo { get; set; }
        //string Locale { get; set; }
    }
    public interface IPredefinedOrderItem
    {
        Branch Branch { get; set; }
        int? Branch_Id { get; set; }
        decimal Charge { get; set; }
        string Concept { get; set; }
        Franchise Franchise { get; set; }
        int? Franchise_Id { get; set; }
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
        Boolean? Optional { get; set; }
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
        int Service_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Service_Id")]
        Service SetupService { get; set; }
    }
    public interface ISetupService
    {
        decimal SetupCharge { get; set; }
    }
    public interface IShortHuman : IHuman
    {
        [Required]
        string Name { get; set; }

    }
    public interface IWebsiteName
    {
        [Required]
        int Branch_Id { get; set; }
        string Suffix { get; set; }
        string Domain { get; set; }
    }
}


