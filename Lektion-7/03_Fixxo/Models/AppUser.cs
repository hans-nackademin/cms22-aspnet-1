﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _03_Fixxo.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [ProtectedPersonalData]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;
    }
}
