using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class Offer: Delete
    {
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Images are byte arrays")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public decimal Amount { get; set; }

        public Currency Currency { get; set; }
        public double? Percentage { get; set; }
        public float Sequence { get; set; }
        public IEnumerable<OfferItem> Items { get; set; }
        public int? OfferTypeId { get; set; }
        [JsonIgnore]
        [ForeignKey("OfferTypeId")]
        public virtual OfferType OfferType { get; set; }
        [Required]
        public int BranchId { get; set; }
        [JsonIgnore]
        [ForeignKey("BranchId")]
        public virtual Model.Branch.Branch Branch { get; set; }
       

    }
}