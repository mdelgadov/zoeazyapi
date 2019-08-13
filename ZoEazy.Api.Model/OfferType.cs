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
        public byte[] Image { get; set; }
        public string ImageSource { get; set; }
        public virtual List<Offer> Offers { get; set; }

        //public virtual LocalBranch LocalBranch { get; set; }
    }
}