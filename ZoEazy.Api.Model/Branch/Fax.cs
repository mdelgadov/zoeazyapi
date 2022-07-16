using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Branch
{
    public class Fax : Model.Fax
    {
        [Required]
        public int BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
    }
}