using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class CustomerPhone : Model.Phone
    {
    
        [Required]
        public string CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        
    }
}