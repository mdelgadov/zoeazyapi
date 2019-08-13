using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Currency
    {
        public Currency()
        {
            //Id = (int)ConfigDefaults.Currency_Id;
            Code = "USD";
            Name = "US Dollar";
            Short = "Dollar";
            Symbol = "$";
        }

        public Currency(string code, string name, string @short, string symbol)
        {
            //Id = id;
            Code = code;
            Name = name;
            Short = @short;
            Symbol = symbol;
        }

        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
        public string Symbol { get; set; }
        public Currency FromCode(string code) {
            if (code == Code) {
                return this;
            }
            throw new Exception("Invalid Currency");
        }
        [JsonIgnore]
        public virtual List<Plan> Plans { get; set; }
    }
}