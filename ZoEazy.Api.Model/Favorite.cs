using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Favorite : Delete, IDish
    {
    
        public string Description { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "This is apparently the right data type, a byte array for an image")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }
        public IEnumerable<FavoritePresentation> FavoritePresentation { get;  }

        [Required]
        public string CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}