using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace _01_Framework.Application.Generators
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
                new Claim(ClaimTypes.Role, authenticationVM.RoleId.ToString())
            };

            if(!string.IsNullOrEmpty(authenticationVM.Email))
                claims.Add(new Claim(ClaimTypes.Email, authenticationVM.Email));

            if(!string.IsNullOrEmpty(authenticationVM.PhoneNumber))
                claims.Add(new Claim(ClaimTypes.MobilePhone,authenticationVM.PhoneNumber));

            var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
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

        public string GetCurrentUserEmail()
        {
            return IsAuthenticated()
                ? _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value
                : "";
        }

        public string GetCurrentUserPhoneNumber()
        {
            return IsAuthenticated()
                ? _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.MobilePhone).Value
                : "";
        }

        public long GetCurrentUserId()
        {
            return IsAuthenticated()
                ? long.Parse(_httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "UserId").Value)
                : 0;
        }
    }
}
