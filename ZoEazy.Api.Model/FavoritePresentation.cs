using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class FavoritePresentation : IPresentation
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }

        public int FavoriteId { get; set; }
        [JsonIgnore][ForeignKey("FavoriteId")]
        public virtual Favorite Favorite { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}