using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace ZoEazy.Api.Model
{
    public class BankAccount {
        //---------------- bank account
        [Required]
        public BankAccountType BankAccountType { get; set; }
        [StringLength(9)]
        public string Routing { get; set; }
        public string RoutingJson { get; set; }
        [StringLength(8)]
        public string Account { get; set; }
        

    }
}

