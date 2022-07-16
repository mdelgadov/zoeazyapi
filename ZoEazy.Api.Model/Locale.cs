//using System.Data.Entity.Spatial;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Locale {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Language { get; set; }
        [Required]

        public int CountryId { get; set; }

        [JsonIgnore]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public string CountryName { get; set; }
        public string LocaleString { get; set; }

    }
}