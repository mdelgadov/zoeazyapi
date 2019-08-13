using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class ContractService 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Contract_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("ContractItem_Id")]
        public virtual ContractItem ContractItem { get; set; }
        public string Concept { get; set; }
        public decimal Charge { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public int Currency_Id { get; set; }
        [JsonIgnore]
        [ForeignKey("Currency_Id")]
        public Currency Currency { get; set; }
        public string Stringify()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}