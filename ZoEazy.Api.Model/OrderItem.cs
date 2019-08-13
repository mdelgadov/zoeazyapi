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

        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }

        public virtual List<OrderItemPresentation> Presentations { get; set; }
        [Required]
        public int Order_Id { get; set; }
        [JsonIgnore][ForeignKey("Order_Id")]
        public virtual Order Order { get; set; }
        public double Quantity { get; set; }
    }
}