using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace _01_Framework.Application
{
    public class AuthenticationHelper:IAuthenticationHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SignIn(AuthenticationViewModel authenticationVM)
        {
            var claims = new List<Claim>()
            {
                new Claim("UserId", authenticationVM.UserId.ToString()),
                new Claim(ClaimTypes.Name, authenticationVM.Email),
                new Claim(ClaimTypes.Role, authenticationVM.RoleId.ToString())
            };
            var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14)
            };
            _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
