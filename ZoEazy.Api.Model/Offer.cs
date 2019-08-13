using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Offer: IDeleted
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public decimal Amount { get; set; }

        public Currency Currency { get; set; }
        public double? Percentage { get; set; }
        public float Sequence { get; set; }
        public virtual List<OfferItem> Items { get; set; }
        public int? OfferType_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("OfferType_Id")]
        public virtual OfferType OfferType { get; set; }
        [Required]
        public int Branch_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Branch_Id")]
        public virtual Branch Branch { get; set; }
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