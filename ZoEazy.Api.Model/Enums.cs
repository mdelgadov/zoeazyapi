using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ZoEazy.Api.Model.Extensions;

namespace ZoEazy.Api.Model
{
    public enum DayOfMonth
    {
        mo1,
        mo2,
        mo3,
        mo4,
        mo5,
        mo6,
        mo7,
        mo8,
        mo9,
        mo10,
        mo11,
        mo12,
        mo13,
        mo14,
        mo15,
        mo16,
        mo17,
        mo18,
        mo19,
        mo20,
        mo21,
        mo22,
        mo23,
        mo24,
        mo25,
        mo26,
        mo27,
        mo28,
        mo29,
        mo30,
        mo31
    }
    public enum MonthsFree {
        zero,
    one,
    two,
    three
    }
    public enum DaysFree
    {
        zero,
        seven = 7,
        fourteen = 14,
        twentyone = 21
    }
    public enum SetupDays { days = 5}
    public enum Hour
    {
        h24, h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15, h16, h17, h18, h19, h20, h21, h22, h23
    }
    public enum HalfHour { hf0, hf30 = 30 }
    public enum MHour
    {
        ah12, ah1, ah2, ah3, ah4, ah5, ah6, ah7, ah8, ah9, ah10, ah11, ph12, ph13, ph15, ph16, ph17, ph18, ph19, ph20, ph21, ph22, ph23
    }
    public enum Minute
    {
        m0, m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m15, m16, m17, m18, m19, m20, m21, m22, m23, m24, m25, m26, m27, m28, m29, m30, m31, m32, m33, m34, m35, m36, m37, m38, m39, m40, m41, m42, m43, m44, m45, m46, m47, m48, m49, m50, m51, m52, m53, m54, m55, m56, m57, m58, m59
    }
    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        Augus,
        September,
        October,
        November,
        December
    }
    public enum Quarter { f0, f15 = 15, f30 = 30, f45 = 45 }
    public enum ApplicationTypes
    {
        JavaScript,
        NativeConfidential
    };
    public enum BankAccountType
    {
        Checking,
        Savings,
    }
    public enum ConfigDefaults
    {
        Radius = 5, RadiusUnit = 1, Finds = 100, QtyTime = 90, Period = 0, Zoom = 14, Takes = 20, Locale_Id = 1, Currency_Id = 1
    }
    public enum CreditCardEnum
    {
        MasterCard,
        Visa,
        AmericanExpress,
        Discover,
        DinersClub
    }
    public enum CornerType
    {
        Corner,
        Place,
        LatLng
    }
    public enum CustomerType
    {
        Regular,
        Corporate
    }
    public enum Entity
    {
        Subscriber, Customer, Franchise, Branch
    }
    public enum PredefinedDay
    {
        // Summary:
        //     Indicates Sunday.
        Sunday = 1,
        //
        // Summary:
        //     Indicates Monday.
        Monday,
        //
        // Summary:
        //     Indicates Tuesday.
        Tuesday,
        //
        // Summary:
        //     Indicates Wednesday.
        Wednesday,
        //
        // Summary:
        //     Indicates Thursday.
        Thursday,
        //
        // Summary:
        //     Indicates Friday.
        Friday,
        //
        // Summary:
        //     Indicates Saturday.
        Saturday,
        // Summary:
        //     january 1st
        Jan1,
        Jul3,
        Jul4,
        TGW,
        TGT,
        TGF,
        CrE,
        Crs,
        Dec31,
        Yom,
        Ros,
        T247,
        None
    }
    public enum Gender
    {
        Undefined,
        Male,
        Female
    };
    public enum InitialWebsiteState
    {
        New, Previous, Inactive
    }
    public enum Lengths { kilometer, mile }
    public enum LongPeriod
    {
        Month = 1,
        Semester = 6,
        Annum = 12
    }
    public enum PersonType
    {
        Subscriber,
        Customer,
        NonHuman
    }
    public enum Redirection
    {
        Subscriber, VerticalVirals
    }
    public enum RequestState
    {
        Failed,
        NotAuth,
        Success,
        Lockout

    }
    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Fall
    };
    public enum ServiceEnum {
        setup
    }
    public enum ContractStatus { Created, Active, Cancelled, Expired }
    public enum ServiceStatus
    {
        Closed, Open
    }
    public enum ServiceLevelEnum
    {
        Directory,
        BaseService,
        WebSite,
        FullService
    }
    public enum ShortPeriod
    {
        Day, Week, Month
    }
    public enum Suffixes
    {
        any,
        com,
        net,
        other
    }
    public enum CreditCardStatus
    {
        inactive,
        active,
        expired
    }
    public class CreditCardDict
    {
        public Dictionary<int, string> Brands { get; set; }

        public CreditCardDict()
        {
            //Brands = CreditCardEnum.AmericanExpress.ToDict();
            var brandsEnum = Enums.Get<CreditCardEnum>();
            Brands = brandsEnum.ToDictionary(brand => (int)brand, brand => brand.ToString());
        }
    }
    public class MonthDict
    {
        public Dictionary<int, string> Months { get; set; }

        public MonthDict()
        {
            //Months = Month.April.ToDict();
            var monthsEnum = Enums.Get<Month>();
            Months = monthsEnum.ToDictionary(month => (int)month, month => month.ToString());
        }
    }

   
}