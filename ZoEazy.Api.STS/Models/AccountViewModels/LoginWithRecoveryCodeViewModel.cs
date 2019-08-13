using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.STS.Models
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required(ErrorMessage = "ACCOUNT_RECOVERY_CODE_REQUIRED")]
        [DataType(DataType.Text)]
        public string RecoveryCode { get; set; }
    }
}
