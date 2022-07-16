using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Branch.Contract
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContractId { get; set; }
        [JsonIgnore]
        [ForeignKey("ContractId")]
        public virtual Contract Contract { get; set; }
        [Required]
        public int PlanId { get; set; }
        public virtual Model.Branch.Plan Plan { get; set; }
        public IEnumerable<Service> Services { get; set; }
        [JsonIgnore]
        public DateTimeOffset ActiveFromUtc { get; set; }
        public DateTimeOffset ActiveToUtc { get; set; }
        
        public Status Active { get; set; }

        [JsonIgnore]
        public string Response { get; set; }
        private DateTimeOffset ResponseTime(string response)
        {
            return DateTimeOffset.Now;
        }
    }
}