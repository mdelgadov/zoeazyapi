using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class AllowedOrigin
    {
        public AllowedOrigin()
        {
            Allowed = true;
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Customer_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }

        [MaxLength(100)]
        public string Origin { get; set; }

        public bool Allowed { get; set; }

    }
}
