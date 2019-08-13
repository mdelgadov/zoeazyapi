using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class MenuPresentation : IPresentation
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }

        public int Menu_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Menu_Id")]
        public virtual Menu Menu { get; set; }

        

        [Required]
        public decimal Price { get; set; }

    }
}