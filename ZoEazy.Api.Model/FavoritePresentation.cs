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

        public int Favorite_Id { get; set; }
        [JsonIgnore][ForeignKey("Favorite_Id")]
        public virtual Favorite Favorite { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}