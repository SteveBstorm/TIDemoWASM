﻿using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Pages.Auth.Models
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}