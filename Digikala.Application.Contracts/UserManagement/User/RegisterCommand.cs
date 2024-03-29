﻿using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Digikala.Application.Contracts.UserManagement.User
{
    public class RegisterCommand
    {
        public string? Email { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MinLength(8,ErrorMessage = ValidationMessages.PasswordMinLength)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Compare(nameof(Password),ErrorMessage = ValidationMessages.InvalidPasswordCompare)]
        public string RepeatPassword { get; set; }
    }
}
