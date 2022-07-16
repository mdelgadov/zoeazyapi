using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ZoEazy.Api.Model
{
    public class Schedule : Delete
    {
     

       
        [Required]
        public int BranchId { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Model.Branch.Branch Branch { get; set; }

        [DefaultValue(PredefinedDay.None)]
        private PredefinedDay _Dow;
        public PredefinedDay? Dow
        {
            get
            {
                return _Dow;
            }
            set
            {
                if (value == null)
                    _Dow = PredefinedDay.None;
                else
                    _Dow = (PredefinedDay)value;
            }
        }
        // public PredefinedDay Dow { get; set; }
        [Range(1, 31, ErrorMessage = "Invalid Day")]

        public Int16? Day { get; set; }

        public Month? Month { get; set; }
        [Range(2000, 2050, ErrorMessage = "Invalid Year")]
        public int? Year { get; set; }

        public ServiceStatus Service { get; set; }

        [Range(0, 23, ErrorMessage = "Invalid Hour")]
        public Hour? OpensHour { get; set; }
        [Range(0, 59, ErrorMessage = "Invalid Minute")]
        public Quarter? OpensMinute { get; set; }
        [Range(0, 23, ErrorMessage = "Invalid Hour")]
        public Hour? ClosesHour { get; set; }
        [Range(0, 59, ErrorMessage = "Invalid Minute")]
        public Quarter? ClosesMinute { get; set; }

        public Boolean CloseOfTheNextDay { get; set; }
        public string Name { get; set; }
        public Boolean? Disable { get; set; }
        public Boolean? Optional { get; set; }
        
    }
}

