using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Application.Contracts.Role;

namespace Server.Areas.Administration.Pages.Roles
{
    public class EditModel : PageModel
    {
        public EditModel(IRoleApplication roleApplication,IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication=roleApplication;
            _exposers=exposers;
        }

        private readonly IEnumerable<IPermissionExposer> _exposers;
        private readonly IRoleApplication _roleApplication;
        [BindProperty]
        public EditRoleCommand Command { get; set; }

        public List<SelectListItem> Permissions { get; set; } = new List<SelectListItem>();
        public void OnGet(long roleId)
        {
            Command = _roleApplication.GetRoleForEdit(roleId);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key,value) in exposedPermissions)
                {
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.PermissionTitle, permission.PermissionCode.ToString())
                        {
                            Group = new SelectListGroup()
                            {
                                Name = key
                            }
                        };
                        if (Command.PermissionCodes.Any(c=>c==permission.PermissionCode))
                            item.Selected = true;
                        Permissions.Add(item);
                    }
                }
            }
        }
    }
}
