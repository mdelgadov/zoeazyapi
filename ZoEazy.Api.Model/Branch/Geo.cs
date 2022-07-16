using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Branch
{
    public class Geo : IId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BranchAddressId { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchAddressId")]
        public Address Address { get; set; }

        public string Geological { get; set; }
    }
}