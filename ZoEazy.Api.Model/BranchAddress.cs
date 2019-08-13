using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZoEazy.Api.Model
{
    public class BranchAddress : IAddress, IId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Branch_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
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
        public int? State_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("State_Id")]
        public State State { get; set; }
        public string Geological { get; set; }

    }
}