using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZoEazy.Api.Model
{
    public class BranchAddressGeo : IId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BranchAddress_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchAddress_Id")]
        public virtual BranchAddress BranchAddress { get; set; }

        public string Geological { get; set; }
    }
}