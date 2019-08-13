namespace ZoEazy.Api.Model
{
    public class LoginData
    {
        public LoginData()
        {
        }

        public LoginData(BearerToken token, string user, string currency, string country, string brands, string cornerTypes, string suffixes, string bankAccountType,  string months, string daysOfMonth, string plans, string hours, string quarters, string creditCardState, string brandsEnum, string locale, string latlng, string websiteEnum, string predefinedSchedules)
        {
            Token = token;
            User = user;
            Currency = currency;
            Country = country;
            Brands = brands;
           CornerTypes = cornerTypes;
            Suffixes = suffixes;
            BankAccountType = bankAccountType;
            Months = months;
            DaysOfMonth = daysOfMonth;
            Plans = plans;
            Hours = hours;
            Quarters = quarters;
            CreditCardState = creditCardState;
            BrandsEnum = brandsEnum;
            Locale = locale;
            LatLng = latlng;
            WebEnum = websiteEnum;
            PredefinedSchedules = predefinedSchedules;
        }

        public BearerToken Token { get; set; }
        public string User { get; set; }
        public string Currency {get; set; }
        public string Country { get; set; }
        public string Brands { get; set; }
        public string CornerTypes { get; set; }
        public string Suffixes { get; set; }
        public string LongPeriods { get; set; }
        public string BankAccountType { get; set; }
        public string PredefinedOrderItems { get; set; }
        public string Months { get; set; }
        public string DaysOfMonth { get; set; }
        public string Plans { get; set; }
        public string Hours { get; set; }
        public string Quarters { get; set; }
        public string CreditCardState { get; set; }
        public string BrandsEnum { get; set; }
        public string Locale { get; set; }
        public string LatLng { get; set; }
        public string WebEnum { get; set; }
        public string PredefinedSchedules { get; set; }

    }
    public class AdminData
    {
        public AdminData()
        {
        }

        public AdminData(string user)
        {
            User = user;
        }

        public string User { get; set; }

    }
}