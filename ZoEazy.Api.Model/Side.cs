using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Side
    {[Key]
        public int Id { get; set; }
        public Corner CornerFrom { get; set; }
        public Corner CornerTo { get; set; }
        [Required]
        public int DeliveryAreaId { get; set; }
        [JsonIgnore]
        [ForeignKey("DeliveryAreaId")]
        public virtual DeliveryArea DeliveryArea { get; set; }
    }
}