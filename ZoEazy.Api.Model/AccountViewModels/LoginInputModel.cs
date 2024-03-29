﻿using System.ComponentModel.DataAnnotations;
using System;
namespace ZoEazy.Api.Model.AccountViewModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "EMAIL_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD_REQUIRED")]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }
        public Uri ReturnUrl { get; set; }
    }
}