using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{

    [ComplexType]
    public class BankAccount : IBankAccount
    {
        [Required]
        public BankAccountType BankAccountType { get; set; }
        [Required]
        public string Routing { get; set; }
        [Required]
        public string Account { get; set; }
    }

    [ComplexType]
    public class Config : IConfig
    {
        public double? Radius { get; set; }
        public double? Zoom { get; set; }
        public IEnumerable<WebsiteName> Websites { get;  }
        public InitialWebsiteState State { get; set; }

        public Redirection Redirection { get; set; }
        public string AppName { get; set; }
        public Length Unit { get; set; }
    }
}


