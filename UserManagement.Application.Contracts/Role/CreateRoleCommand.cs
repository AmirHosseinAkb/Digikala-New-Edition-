using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application.Generators;
using _01_Framework.Infrastructure;

namespace UserManagement.Application.Contracts.Role
{
    public class CreateRoleCommand
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(200,ErrorMessage = ValidationMessages.MaxLenght)]
        public string RoleTitle { get; set; }

        public List<int>? PermissionCodes { get; set; }
    }
}
