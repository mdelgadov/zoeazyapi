using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Footnote { get; set; }
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }
        public virtual List<MenuItem> Items { get; set; }

        
        public virtual List<MenuPresentation> Presentations { get; set; }
        
        [Required]
        public int Branch_Id { get; set; }
        [JsonIgnore][ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
    }
}