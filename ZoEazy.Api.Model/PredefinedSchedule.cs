using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class PredefinedSchedule : IPredefinedSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public PredefinedDay Dow { get; set; }

        public string Name { get; set; }
        
        public ServiceStatus? Service { get; set; }
        public Hour? OpensHour { get; set; }
        public DayOfMonth? Day { get; set; }
        public Month? Month { get; set; }
        public int? Year { get; set; }
        public Quarter? OpensMinute { get; set; }
        public Hour? ClosesHour { get; set; }
        public Quarter? ClosesMinute { get; set; }
        public Boolean? Disable { get; set; }
        public Boolean? Optional { get; set; }
        public Boolean? CloseOfTheNextDay { get; set; }
    }
}

