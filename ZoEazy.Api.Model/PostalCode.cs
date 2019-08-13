using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class PostalCode
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int Branch_Id { get; set; }

        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
        [Required]
        public string Code { get; set; }
        [JsonIgnore]
        public bool Valid { get; set; }
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

                _Deleted = (value == null || value == false) ? false : true;
                if (_Deleted) DeletedUtc = DateTimeOffset.Now;
            }
        }
        [JsonIgnore]
        public DateTimeOffset DeletedUtc { get; set; }
          }
}
