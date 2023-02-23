﻿namespace _02_ProfileAndImageUpload.Models.Identity
{
    public class Profile
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ImageName { get; set; }
    }
}
