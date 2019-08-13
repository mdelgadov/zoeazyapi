using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class AudienceModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }

    

}