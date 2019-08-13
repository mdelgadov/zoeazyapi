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
        public int DeliveryArea_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("DeliveryArea_Id")]
        public virtual DeliveryArea DeliveryArea { get; set; }
    }
}