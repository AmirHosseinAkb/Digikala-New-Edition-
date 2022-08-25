using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;

namespace Digikala.Application.Contracts.UserManagement.User
{
    public class LoginCommand
    {
        public string? Email { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MinLength(8,ErrorMessage = ValidationMessages.PasswordMinLength)]
        public string Password { get; set; }
    }
}
