using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{

    public class Audience
    {
        [Key]
        public int Id { get; set; }

        public string ClientId { get; set; }

        [MaxLength(80)]
        [Required]
        public string Base64Secret { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Branch_Id { get; set; }
        

        [JsonIgnore][ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
    }

    

}