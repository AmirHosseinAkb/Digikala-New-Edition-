using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digikala.Application.Contracts.UserManagement.User
{
    public class EmailViewModel
    {
        public string Email { get; set; }
        public string ActivationCode { get; set; }
    }
}
