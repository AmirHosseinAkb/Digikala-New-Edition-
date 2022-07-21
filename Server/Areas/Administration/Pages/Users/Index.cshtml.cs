using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Application.Contracts.Role;
using UserManagement.Application.Contracts.User;
using UserManagement.Application.Contracts.User.Administration;

namespace Server.Areas.Administration.Pages.Users
{
    public class IndexModel : PageModel
    {

        public IndexModel(IUserApplication userApplication, IRoleApplication roleApplication)
        {
            _userApplication = userApplication;
            _roleApplication = roleApplication;
        }
        private readonly IUserApplication _userApplication;
        private readonly  IRoleApplication _roleApplication;
        public Tuple<List<UserAdminInformationsViewModel>,int,int,int> UsersInformationsVm { get; set; }
        [BindProperty]
        public CreateUserCommand CreateUserCommand { get; set; }
        
        public void OnGet(int pageId = 1, string fullName = "", string email = "", string phoneNumber = "", int take = 20)
        {
            ViewData["Take"] = take;
            ViewData["Roles"] = _roleApplication.GetRoles();
            UsersInformationsVm = _userApplication.GetUsersAdminInformationsForShow(pageId,fullName,email,phoneNumber,take);
        }

        public IActionResult OnPostCreateUser()
        {

            return RedirectToPage();
        }

        public IActionResult OnGetIsExistEmailOrPhoneNumber(string email = "", string phoneNumber = "")
        {
            return Content(_userApplication.IsExistEmailOrPhoneNumber(email, phoneNumber).ToString().ToLower());
        }
    }
}