using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    class Address : IAddress
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
        

        public int? State_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("State_Id")]
        public virtual State State { get; set; }


    }
}
