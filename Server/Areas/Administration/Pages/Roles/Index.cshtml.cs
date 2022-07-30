using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Application.Contracts.Role;

namespace Server.Areas.Administration.Pages.Roles
{
    public class IndexModel : PageModel
    {

        public IndexModel(IRoleApplication roleApplication,IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }
        private readonly IRoleApplication _roleApplication;

        private readonly IEnumerable<IPermissionExposer> _exposers;

        public List<RoleViewModel> RoleVm { get; set; }

        public List<SelectListItem> Permissions { get; set; } = new List<SelectListItem>();
        public CreateRoleCommand Command { get; set; }
        public void OnGet()
        {
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key,value) in exposedPermissions)
                {
                    foreach (var permission in value)
                    {
                        Permissions.Add( new SelectListItem(permission.PermissionTitle, permission.PermissionCode.ToString())
                        {
                            Group = new SelectListGroup(){Name = key}
                        });
                    }
                }
            }
            RoleVm = _roleApplication.GetRoles();
        }

        public IActionResult OnPostCreateRole()
        {
            if (!ModelState.IsValid)
                return RedirectToPage();
            return null;
        }
    }
}
