using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Franchise
{
    public class Fax : Model.Fax
    {
        [Required]
        public int FranchiseId { get; set; }

        [JsonIgnore]
        [ForeignKey("FranchiseId")]
        public Franchise Franchise { get; set; }
    }
}