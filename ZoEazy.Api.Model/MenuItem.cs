using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class MenuItem : IDish
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

       public virtual List<MenuItemPresentation> Presentations { get; set; }


        [Required]
        public int Menu_Id { get; set; }
        [JsonIgnore][ForeignKey("Menu_Id")]
        public virtual Menu Menu { get; set; }
    }
}