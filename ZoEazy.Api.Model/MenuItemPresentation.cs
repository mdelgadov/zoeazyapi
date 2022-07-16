using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class MenuItemPresentation : IPresentation
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }

        [Required]
        public int MenuItemId { get; set; }
        [JsonIgnore]
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}