using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class MenuItem : Delete, IDish
    {
        public string Description { get; set; }
        public string Footnote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Image is a byte array")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }
        public IEnumerable<MenuItemPresentation> Presentations { get;  }
        [Required]
        public int MenuId { get; set; }
        [JsonIgnore]
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }
}