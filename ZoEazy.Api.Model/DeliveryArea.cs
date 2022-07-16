using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class DeliveryArea : Delete
    {
      

        [Required]
        public int BranchId { get; set; }

        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Branch.Branch Branch { get; set; }

        public IEnumerable<Corner> Corners { get;  }
        public IEnumerable<Side> Sides { get;  }

        public bool IsClosed { get;  }
        

    }

}