using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    
    public class Service : IService
    {
        [Key]
        public int Id { get; set; }
        public Service()
        {
            Charge = 0;
        }

        public Service(decimal charge)
        {
            Charge = charge;
        }

        [Required]
        public decimal Charge { get; set; }
        
       
    }
    public class SetupService : ISetupService
    {
        [Key]
        public int Id { get; set; }
        public SetupService()
        {
            SetupCharge = 0;
        }

        public SetupService(decimal charge)
        {
            SetupCharge = charge;
        }

        [Required]
        public decimal SetupCharge { get; set; }
    }
}