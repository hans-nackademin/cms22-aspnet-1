﻿using System.ComponentModel.DataAnnotations;

namespace _01_Assignment.Models
{
    public class SignInForm
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;
    }
}
