using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Favorite : IDish
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }
        public List<FavoritePresentation> FavoritePresentation { get; set; }

        [Required]
        public string Customer_Id { get; set; }

        [JsonIgnore][ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }
    }
}