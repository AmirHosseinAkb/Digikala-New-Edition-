using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Application.Contracts.User;

namespace Server.Pages.Account
{
    public class RegisterAndLoginModel : PageModel
    {

        public RegisterAndLoginModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        private readonly IUserApplication _userApplication;
        
        [BindProperty]
        public RegisterAndLoginCommand RegisterAndLoginVM { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}
