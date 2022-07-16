using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class WebsiteName : Delete, IWebsiteName
    {
        [Required]
        public int BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Model.Branch.Branch Branch { get; set; }
        public string Suffix { get; set; }
        public string Domain { get; set; }
        
    }
}