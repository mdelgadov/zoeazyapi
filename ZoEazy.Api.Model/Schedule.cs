using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ZoEazy.Api.Model
{
    public class Schedule : IDeleted, IId
    {
        public Schedule() {
            Deleted = false;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Branch_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }

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
        [DefaultValue(false)]
        private bool _Deleted;
        public bool? Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                if (value == null) value = false;
                _Deleted = (bool)value;
                if (_Deleted) DeletedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset DeletedUtc { get; set; }
    }
}

