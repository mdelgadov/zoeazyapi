using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class Setup
    {
        public Setup()
        {
            Charge = 0;
            Prepaid = 0;
            Net = 0;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public ServiceLevelEnum ServiceLevel { get; set; }
        [Required]
        public decimal Charge { get; set; }
        public decimal Prepaid { get; set; }
        public decimal Net { get; set; }
        public decimal Discount { get; set; }
    }
}