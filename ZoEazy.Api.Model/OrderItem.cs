using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZoEazy.Api.Model
{
    public class OrderItem : IDish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Images are byte arrays")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }

        public IEnumerable<OrderItemPresentation> Presentations { get; set; }
        [Required]
        public int OrderId { get; set; }
        [JsonIgnore][ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public double Quantity { get; set; }
    }
}