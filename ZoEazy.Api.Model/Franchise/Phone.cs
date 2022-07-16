using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Franchise
{
    public class Phone : Model.Phone
    {
        [Required]
        public int FranchiseId { get; set; }

        [JsonIgnore]
        [ForeignKey("FranchiseId")]
        public Franchise Franchise { get; set; }
    }
}