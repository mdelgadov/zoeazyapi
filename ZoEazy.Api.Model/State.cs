using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class State 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } // iso 3166 two letter


        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        
        [Required]

        public int Country_Id { get; set; }

        [JsonIgnore][ForeignKey("Country_Id")]
        
        public virtual Country Country { get; set; }

        
    }
}