using _01_Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Server
{
    [HtmlTargetElement(Attributes="Permission")]
    public class PermissionTagHelper:TagHelper
    {
        public int[] PermissionCodes { get; set; }
        private readonly IAuthenticationHelper _authenticationHelper;

        public PermissionTagHelper(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authenticationHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            var permissions = _authenticationHelper.GetCurrentUserPermissions();
            if (!permissions.Intersect(PermissionCodes).Any())
            {
                output.SuppressOutput();
                return;
            }
            base.Process(context, output);
        }
    }
}
