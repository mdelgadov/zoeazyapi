using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Branch
{
    public class PostalCode: Delete
    {

        [Required]
        public int BranchId { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
        [Required]
        public string Code { get; set; }
        [JsonIgnore]
        public bool Valid { get; set; }
        
          }
}
