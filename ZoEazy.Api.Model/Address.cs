using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public abstract class Address : Delete, IAddress 
    {
        [Required]
        public string Street { get; set; }
        public string Apartment { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MaxLength(5), MinLength(5)]
        public string PostalCode { get; set; }
        [JsonIgnore]
        public double Latitude { get; set; }
        [JsonIgnore]
        public double Longitude { get; set; }


        public int StateId { get; set; }

        [JsonIgnore]
        [ForeignKey("StateId")]
        public State State { get; set; }

        public string Geological { get; set; }


    }

}
