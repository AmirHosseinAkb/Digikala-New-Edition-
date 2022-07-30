using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Application.Contracts.Role;

namespace Server.Areas.Administration.Pages.Roles
{
    public class IndexModel : PageModel
    {
        public string ErrorMessage { get; set; }
        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
        private readonly IRoleApplication _roleApplication;


        public List<RoleViewModel> RoleVm { get; set; }


        public void OnGet()
        {
            RoleVm = _roleApplication.GetRoles();
        }

        public IActionResult OnPostDeleteRole(long roleId)
        {
            var result = _roleApplication.Delete(roleId);
            if (!result.IsSucceeded)
            {
                RoleVm = _roleApplication.GetRoles();
                ErrorMessage = result.Message;
                return Page();
            }
            return RedirectToPage();
        }
    }
}
