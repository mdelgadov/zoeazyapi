using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class FranchisePhone : Phone
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public int Franchise_Id { get; set; }

        [JsonIgnore] [ForeignKey("Franchise_Id")]
        public virtual Franchise Franchise { get; set; }
       
    }
}