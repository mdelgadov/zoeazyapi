using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class DeliveryArea : IDeleted
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Branch_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }

        public virtual List<Corner> Corners { get; set; }
        public virtual List<Side> Sides { get; set; }

        public bool IsClosed { get; set; }
        [DefaultValue(false)]
        private bool _Deleted;
        public bool? Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                if (value == null) value = false;
                _Deleted = (bool)value;
                if (_Deleted) DeletedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset DeletedUtc { get; set; }

    }

}