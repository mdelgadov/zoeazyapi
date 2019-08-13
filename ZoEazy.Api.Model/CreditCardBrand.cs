using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class CreditCardBrand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public CreditCardEnum Id { get; set; }
        public string Name { get; set; }
        public string Mnemonic { get; set; }
        public string Pattern { get; set; }
        public string EagerPattern { get; set; }
        public string GroupPattern { get; set; }
        public int CvcLength { get; set; }
        public string TestNumber { get; set; }
        public string MaskArray { get; set; }
        public string CvcName { get; set; }
    }
}