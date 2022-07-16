using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZoEazy.Api.Model.Branch
{
    public class Address : Model.Address
    {
        [Required]
        public int BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

    }
}