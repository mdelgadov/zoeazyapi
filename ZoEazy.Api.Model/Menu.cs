using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Menu: Delete
    {
   
        public string Description { get; set; }
        public string Footnote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Image is a byte array")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }
        public IEnumerable<MenuItem> Items { get;  }

        
        public IEnumerable<MenuPresentation> Presentations { get;  }
        
        [Required]
        public int BranchId { get; set; }
        [JsonIgnore][ForeignKey("BranchId")]
        public virtual Model.Branch.Branch Branch { get; set; }
    }
}