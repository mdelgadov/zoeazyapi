using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model.Branch.Contract
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContractId { get; set; }
        [JsonIgnore]
        [ForeignKey("ContractItemId")]
        public virtual Item Item { get; set; }
        public string Concept { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [JsonIgnore]
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        public string Stringify()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}