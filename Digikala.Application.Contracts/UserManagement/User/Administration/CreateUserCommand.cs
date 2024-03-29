﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using FoolProof.Core;
using Microsoft.AspNetCore.Http;

namespace Digikala.Application.Contracts.UserManagement.User.Administration
{
    public class CreateUserCommand
    {
        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLength)]
        [EmailAddress(ErrorMessage = ValidationMessages.InvalidEmail)]
        [RequiredIfEmpty(nameof(PhoneNumber), ErrorMessage = ValidationMessages.EnterEmailOrPhoneNumber)]
        public string? Email { get; set; }

        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLength)]
        [MinLength(8, ErrorMessage = ValidationMessages.PasswordMinLength)]
        [DataType(DataType.Password)]
        [RequiredIfNotEmpty(nameof(Email), ErrorMessage = ValidationMessages.PasswordRequiredIfEmailNotEmpty)]
        public string? Password { get; set; }


        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLength)]
        public string? FirstName { get; set; }

        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLength)]
        public string? LastName { get; set; }

        [RequiredIfEmpty(nameof(Email), ErrorMessage = ValidationMessages.EnterEmailOrPhoneNumber)]
        [StringLength(11,MinimumLength = 11,ErrorMessage =ValidationMessages.PhoneNumberLength )]
        [Range(0,long.MaxValue,ErrorMessage = ValidationMessages.IntegerValue)]
        public string? PhoneNumber { get; set; }
        public IFormFile? UserAvatar { get; set; }
    }
}
