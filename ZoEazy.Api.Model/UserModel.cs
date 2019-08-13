using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Invalid Key.", MinimumLength = 32)]
        public string ClientId { get; set; }

    }


}
   
