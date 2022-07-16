using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZoEazy.Api.Model
{

    public class CustomerAddress : IAddress
    {
      
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [JsonIgnore][ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Required]
        public string Street { get; set; }
        public string Apartment { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MaxLength(5), MinLength(5)]
        public string PostalCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        //[TsIgnore]
        // public DbGeography Position { get; set; }

        public int StateId { get; set; }

        [JsonIgnore][ForeignKey("StateId")]
        public virtual State State { get; set; }



    }
}