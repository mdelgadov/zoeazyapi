using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ZoEazy.Api.Model
{
    public class ContractItem : IContractItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Contract_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Contract_Id")]
        public virtual Contract Contract { get; set; }
        [Required]
        public int Plan_Id { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual List<ContractService> Services { get; set; }
        [JsonIgnore]
        public DateTimeOffset ActiveFromUtc { get; set; }
        public DateTimeOffset ActiveToUtc { get; set; }
        [DefaultValue(false)]
        private bool _Active;
        public bool Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
                if (_Active)
                {
                    ActiveFromUtc = ResponseTime(Response);
                    ActiveToUtc = ActiveFromUtc.AddDays((int)Plan.DaysFree).AddMonths((int)Plan.Period_Id);
                }

            }
        }
        [JsonIgnore]
        public string Response { get; set; }
        private DateTimeOffset ResponseTime(string response)
        {
            return DateTimeOffset.Now;
        }
    }
}