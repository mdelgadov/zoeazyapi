using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class FranchiseFax : IFax, IDeleted
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        [Required]
        public int Franchise_Id { get; set; }

        [JsonIgnore][ForeignKey("Franchise_Id")]
        public virtual Franchise Franchise { get; set; }
        //public string Locale { get; set; }

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