﻿using System.ComponentModel.DataAnnotations;

namespace Fixxo.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [Display(Name = "Your E-Mail Address")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Keep me Logged In!")]
        public bool RememberMe { get; set; } = false;

        public string ReturnUrl { get; set; } = "/";
    }
}
