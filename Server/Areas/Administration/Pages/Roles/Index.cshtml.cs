using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Application.Contracts.Role;

namespace Server.Areas.Administration.Pages.Roles
{
    public class IndexModel : PageModel
    {

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

       
    }
}
