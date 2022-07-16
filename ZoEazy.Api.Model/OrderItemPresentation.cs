using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace ZoEazy.Api.Model
{
    public class OrderItemPresentation : IPresentation
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }

        public int OrderItemId { get; set; }
        [JsonIgnore][ForeignKey("OrderItemId")]
        public virtual OrderItem OrderItem { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}