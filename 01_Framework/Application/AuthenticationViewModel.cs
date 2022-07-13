using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application
{
    public class AuthenticationViewModel
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string Email { get; set; }

        public AuthenticationViewModel()
        {
            
        }

        public AuthenticationViewModel(long userId,long roleId,string roleTitle,string email)
        {
            UserId=userId;
            RoleId=roleId;
            Email = email;
        }
    }
}
