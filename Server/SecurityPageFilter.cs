using System.Reflection;
using _01_Framework.Application.Generators;
using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Server
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthenticationHelper _authenticationHelper;

        public SecurityPageFilter(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!_authenticationHelper.IsAuthenticated())
                context.HttpContext.Response.Redirect("/RegisterAndLogin");

            var handlerPermission =(NeedsPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedsPermissionAttribute));

            var currentUserPermissions = _authenticationHelper.GetCurrentUserPermissions();

            if (currentUserPermissions == null)
                return;

            if(!currentUserPermissions.Contains(handlerPermission.PermissionId))
                context.HttpContext.Response.Redirect("/RegisterAndLogin");

        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }
    }
}
