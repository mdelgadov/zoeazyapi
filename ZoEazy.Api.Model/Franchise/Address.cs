using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZoEazy.Api.Model.Franchise
{
    public class Address : Model.Address
    {
        [Required]
        public int FranchiseId { get; set; }

        [JsonIgnore]
        [ForeignKey("FranchiseId")]
        public Franchise Franchise { get; set; }
    }
}