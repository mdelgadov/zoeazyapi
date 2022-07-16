using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class OfferItemPresentation : IPresentation
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }

        public int OfferItemId { get; set; }
        [JsonIgnore][ForeignKey("OfferItemId")]
        public virtual OfferItem OfferItem { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}