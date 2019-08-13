using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace ZoEazy.Api.Model
{
    public class Corner : IDeleted
    {
        [Key]
        public int Id { get; set; }
        public CornerType Type { get; set; }
        public string StreetOf { get; set; }
        public string StreetAnd { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        [Required]
        public int Zip { get; set; }

        [JsonIgnore]
        [ForeignKey("Zip")]
        public ZipCode PostalCode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required]
        public int DeliveryArea_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("DeliveryArea_Id")]
        public virtual DeliveryArea DeliveryArea { get; set; }
        // [JsonIgnore]
        // public DbGeography Position { get; set; }
        public string Geo { get; set; }

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