using Microsoft.Spatial;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using System.Data.Entity.Spatial;

namespace ZoEazy.Api.Model
{
    public class Corner : Delete
    {
        
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
        public int DeliveryAreaId { get; set; }
        [JsonIgnore]
        [ForeignKey("DeliveryAreaId")]
        public virtual DeliveryArea DeliveryArea { get; set; }
        [JsonIgnore]
        public Geography Position { get; set; }
        public string Geo { get; set; }

        
    }
}