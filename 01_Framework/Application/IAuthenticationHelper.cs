using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Generators
{
    public interface IAuthenticationHelper
    {
        void SignIn(AuthenticationViewModel authenticationVM);
        bool IsAuthenticated();
        void SignOut();
        string GetCurrentUserEmail();
        string GetCurrentUserPhoneNumber();
        long GetCurrentUserId();
    }
}
