using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class OfferItem : Delete, IDish
    {
        public string Description { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Images are byte array")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public float Sequence { get; set; }
        public IEnumerable<OfferItemPresentation> OfferItemPresentations { get; set; }
        [Required]
        public int OfferId { get; set; }
        [JsonIgnore]
        [ForeignKey("OfferId")]
        public virtual Offer Offer { get; set; }

    }
}