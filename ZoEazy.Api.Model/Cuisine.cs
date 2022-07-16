using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Cuisine : Delete
    {
        public int BranchId { get; set; }
        [JsonIgnore][ForeignKey("BranchId")]
        public virtual Model.Branch.Branch Branch { get; set; }
    }
}