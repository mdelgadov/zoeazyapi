using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class OfferType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Image is a byte array")]
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public IEnumerable<Offer> Offers { get;  }

        //public virtual LocalBranch LocalBranch { get; set; }
    }
}