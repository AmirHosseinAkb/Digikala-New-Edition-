using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Application.Contracts.User;
using UserManagement.Application.Contracts.User.UserPanel;

namespace Server.Pages.UserPanel
{
    [Authorize]
    public class ConfirmInformationsModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        public ConfirmInformationsModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }


        public UserInformationsViewModel UserInformationsVM { get; set; }
        public void OnGet()
        {
            UserInformationsVM = _userApplication.GetUserInformationsForShow(User.Identity.Name);
        }

        [BindProperty]
        public FullNameCommand FullNameCommand { get; set; }
        [BindProperty]
        public EmailCommand EmailCommand { get; set; }
        [BindProperty]
        public PhoneNumberCommand PhoneNumberCommand { get; set; }
        [BindProperty]
        public NationalNumberCommand NationalNumberCommand { get; set; }
        [BindProperty]
        public RefundCommand RefundCommand { get; set; }
        [BindProperty]
        public BirthDateCommand BirthDateCommand { get; set; }
        [BindProperty]
        public PasswordCommand PasswordCommand { get; set; }

    }
}
