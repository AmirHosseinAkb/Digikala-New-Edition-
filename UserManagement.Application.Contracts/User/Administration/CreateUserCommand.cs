﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application.Convertors;
using FoolProof.Core;
using Microsoft.AspNetCore.Http;

namespace UserManagement.Application.Contracts.User.Administration
{
    public class CreateUserCommand
    {
        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLenght)]
        [EmailAddress(ErrorMessage = ValidationMessages.InvalidEmail)]
        [RequiredIfEmpty(nameof(PhoneNumber), ErrorMessage = ValidationMessages.EnterEmailOrPhoneNumber)]
        public string? Email { get; set; }

        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLenght)]
        [MinLength(8, ErrorMessage = ValidationMessages.PasswordMinLength)]
        [DataType(DataType.Password)]
        [RequiredIfNotEmpty(nameof(Email), ErrorMessage = ValidationMessages.PasswordRequiredIfEmailNotEmpty)]
        public string? Password { get; set; }


        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLenght)]
        public string? FirstName { get; set; }

        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLenght)]
        public string? LastName { get; set; }

        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLenght)]
        [RequiredIfEmpty(nameof(Email), ErrorMessage = ValidationMessages.EnterEmailOrPhoneNumber)]
        public string? PhoneNumber { get; set; }
        public IFormFile? UserAvatar { get; set; }
    }
}