using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{

    public class ResendEmailConfirmationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(32, ErrorMessage = "Invalid Key.", MinimumLength = 32)]
        public string ClientId { get; set; }
    }


}
   
