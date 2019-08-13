using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "EMAIL_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD_REQUIRED")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "CONFIRM_PASSWORD_NOT_MATCHING")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterComplexViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(250)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

    }
}

