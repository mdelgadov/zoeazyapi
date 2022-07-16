using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Model
{
    public class Currency: Delete
    {
        public Currency()
        {
            Code = "USD";
            Name = "US Dollar";
            ShortName = "Dollar";
            Symbol = "$";
        }

        public Currency(string code, string name, string shortName, string symbol)
        {
            Code = code;
            Name = name;
            ShortName = shortName;
            Symbol = symbol;
        }

        [Key]
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string Symbol { get; set; }
        public Currency FromCode(string code) {
            if (code == Code) {
                return this;
            }
#pragma warning disable CA1303 // Do not pass literals as localized parameters
            throw new Exception("Invalid Currency");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
        }
        [JsonIgnore]
        public IEnumerable<Plan> Plans { get;  }
    }
}