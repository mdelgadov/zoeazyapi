﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoEazy.Api.Model.StripeEntities;
namespace ZoEazy.Api.Model
{
    public partial class Feature
    {
        public int Id { get; set; }
        [Required]
        public int Plan_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Plan_Id")]
        public virtual Plan Plan { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
    }
    
}
