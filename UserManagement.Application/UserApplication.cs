using System.Globalization;
using _01_Framework.Application;
using _01_Framework.Application.Convertors;
using _01_Framework.Application.Email;
using _01_Framework.Infrastructure;
using _01_Framework.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UserManagement.Application.Contracts.User;
using UserManagement.Application.Contracts.User.UserPanel;
using UserManagement.Domain.TransactionAgg;
using UserManagement.Domain.UserAgg;

namespace UserManagement.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IViewRenderService _viewRenderService;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthenticationHelper _authenticationHelper;

        public UserApplication(IUserRepository userRepository, IViewRenderService viewRenderService, IEmailService emailService, IPasswordHasher passwordHasher, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _viewRenderService = viewRenderService;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _authenticationHelper = authenticationHelper;
        }

        public OperationResult RegisterAndLogin(RegisterAndLoginCommand command)
        {
            var result = new OperationResult();
            if (command.EmailOrPhone.IsEmail())
            {
                var user = _userRepository.GetUserByEmail(EmailConvertor.FixEmail(command.EmailOrPhone));
                if (user != null)
                {
                    if (!user.IsActive)
                        return result.Failed(ApplicationMessages.UserIsNotActive);
                }

                return result.Succeeded(command.EmailOrPhone);
            }

            else if (command.EmailOrPhone.IsPhoneNumber())
                return result.Succeeded();

            else
                return result.Failed(ApplicationMessages.InvalidEmailOrPhoneNumber);
        }

        public OperationResult Register(RegisterCommand command)
        {
            var operation = new OperationResult();
            if (_userRepository.IsExistByEmail(command.Email))
                return operation.Failed(ApplicationMessages.DuplicatedEmail);

            var activationCode = CodeGenerator.GenerateUniqName();
            var hashedPassword = _passwordHasher.HashMD5(command.Password);
            var user = new User(activationCode, CodeGenerator.GenerateRandomNumber()
                    , 3, email: command.Email, password: hashedPassword);

            var body = _viewRenderService.RenderToStringAsync
                ("_ActivationEmailBody", new EmailViewModel() { Email = command.Email, ActivationCode = activationCode }); // Email Body
            _emailService.SendEmail(command.Email, DataDictionaries.ActiveAccount, body); //Send Email
            _userRepository.Add(user);

            return operation.Succeeded();
        }

        public OperationResult Login(LoginCommand command)
        {
            var operation = new OperationResult();
            var user = _userRepository.GetUserForLogin(EmailConvertor.FixEmail(command.Email!), _passwordHasher.HashMD5(command.Password));

            if (user == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);
            if (!user.IsActive)
                return operation.Failed(ApplicationMessages.UserIsNotActive);
            var authVm = new AuthenticationViewModel(user.UserId, user.RoleId, user.Email, user.PhoneNumber);
            _authenticationHelper.SignIn(authVm);
            return operation.Succeeded();
        }

        public OperationResult ForgetPassword(ForgetPasswordCommand command)
        {
            var result = new OperationResult();
            var user = _userRepository.GetUserByEmail(command.Email);
            if (user == null || !user.IsActive)
                return result.Failed(ApplicationMessages.RecordNotFound);
            var body = _viewRenderService.RenderToStringAsync("_ForgetPasswordEmailBody",
                new EmailViewModel() { Email = command.Email, ActivationCode = user.ActivationCode });
            _emailService.SendEmail(command.Email, DataDictionaries.ResetPassword, body);
            return result.Succeeded();
        }

        public OperationResult ResetPassword(ResetPasswordCommand command)
        {
            var result = new OperationResult();
            var user = _userRepository.GetByActivationCode(command.ActivationCode);
            if (user == null)
                return result.NullResult(ApplicationMessages.RecordNotFound);
            if (user.Password != _passwordHasher.HashMD5(command.CurrentPassword))
                return result.Failed(ApplicationMessages.InvalidCurrentPassword);
            var hashedPassword = _passwordHasher.HashMD5(command.NewPassword);
            user.ResetPassword(hashedPassword);
            _userRepository.SaveChanges();

            return result.Succeeded();
        }

        public bool ActiveAccount(string activationCode)
        {
            var operation = new OperationResult();
            var user = _userRepository.GetByActivationCode(activationCode);
            if (user == null || user.IsActive)
                return false;
            user.Activate();
            user.ChangeActivationCode(CodeGenerator.GenerateUniqName());
            _userRepository.SaveChanges();

            return true;
        }

        public bool IsExistByEmail(string email)
        {
            return _userRepository.IsExistByEmail(email);
        }

        public void SignOut()
        {
            _authenticationHelper.SignOut();
        }

        public UserInformationsViewModel GetUserInformationsForShow()
        {
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            return new UserInformationsViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                RefundType = user.RefundType,
                BirthDate = user.BirthDate?.ToShamsi(),
                NationalNumber = user.NationalNumber,
                AccountNumber = user.AccountNumber
            };
        }

        public SidebarInformationsViewModel GetUserSidebarInformationsForShow()
        {
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            return new SidebarInformationsViewModel()
            {
                FullName = user.FirstName + " " + user.LastName,
                PhoneNumber = user.PhoneNumber,
                WalletBalance = _userRepository.GetUserWalletBalance(user.UserId),
                AvatarName = user.AvatarName
            };
        }

        public string ConfirmUserFullName(FullNameCommand command)
        {
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            user.ChangeFullName(command.FirstName, command.LastName);
            _userRepository.SaveChanges();
            return user.FirstName + " " + user.LastName;
        }

        public OperationResult ConfirmUserEmail(EmailCommand command)
        {
            var result = new OperationResult();
            if (!command.Email.IsEmail())
                return result.Failed(ApplicationMessages.InvalidEmail);

            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            if (user.Email == EmailConvertor.FixEmail(command.Email))
                return result.Failed(ApplicationMessages.IdenticalEmailEntered);

            if (_userRepository.IsExistByEmail(EmailConvertor.FixEmail(command.Email)))
                return result.Failed(ApplicationMessages.DuplicatedEmail);
            user.ChangeEmail(EmailConvertor.FixEmail(command.Email));
            _userRepository.SaveChanges();
            //Login With New Email
            var authVm = new AuthenticationViewModel(user.UserId, user.RoleId, user.Email, user.PhoneNumber);
            _authenticationHelper.SignOut();
            _authenticationHelper.SignIn(authVm);
            return result.Succeeded();
        }

        public OperationResult ConfirmUserPhoneNumber(PhoneNumberCommand command)
        {
            var result = new OperationResult();

            if (!command.PhoneNumber.IsPhoneNumber())
                return result.Failed(ApplicationMessages.InvalidPhoneNumber);

            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());

            if (user.PhoneNumber == command.PhoneNumber)
                result.Failed(ApplicationMessages.IdenticalPhoneNumberEntered);

            if (_userRepository.IsExistByPhoneNumber(command.PhoneNumber))
                return result.Failed(ApplicationMessages.DuplicatedPhone);

            user.ChangePhoneNumber(command.PhoneNumber);
            _userRepository.SaveChanges();
            var authVm = new AuthenticationViewModel(user.UserId, user.RoleId, user.Email, user.PhoneNumber);
            _authenticationHelper.SignOut();
            _authenticationHelper.SignIn(authVm);
            return result.Succeeded();
        }

        public string ConfirmUserNationalNumber(NationalNumberCommand command)
        {
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            user.ChangeNationalNumber(command.NationalNumber);
            _userRepository.SaveChanges();
            return command.NationalNumber;
        }

        public string ConfirmUserBirthDate(BirthDateCommand command)
        {
            var result = new OperationResult();
            var date = new DateTime(command.BirthYear, command.BirthMonth, command.BirthDay, new PersianCalendar());
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            user.ChangeBirthDate(date);
            _userRepository.SaveChanges(); ;
            return date.ToShamsi();
        }

        public OperationResult ConfirmUserPassword(PasswordCommand command)
        {
            var result = new OperationResult();
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            if (user.Password != _passwordHasher.HashMD5(command.CurrentPassword.Replace(" ", "")))
                return result.Failed(ApplicationMessages.InvalidCurrentPassword);
            user.ResetPassword(_passwordHasher.HashMD5(command.NewPassword.Replace(" ", "")));
            _userRepository.SaveChanges();
            return result.Succeeded();
        }

        public OperationResult ConfirmUserRefundType(RefundCommand command)
        {
            var result = new OperationResult();
            var user = _userRepository.GetUserById(_authenticationHelper.GetCurrentUserId());
            if (command.RefundType == RefundTypes.PayToAccountNumber)
            {
                if (command.AccountNumber.IsAccountNumber())
                {
                    user.ChangeRefundType(RefundTypes.PayToAccountNumber);
                    user.ChangeAccountNumber(command.AccountNumber);
                    _userRepository.SaveChanges();
                    return result.Succeeded(DataDictionaries.PayToAccountNumber+" - "+command.AccountNumber);
                }
                return result.Failed(ApplicationMessages.InvalidAccountNumber);
            }
            else if (command.RefundType == RefundTypes.PayToWallet)
            {
                user.ChangeRefundType(RefundTypes.PayToWallet);
                _userRepository.SaveChanges();
                return result.Succeeded(DataDictionaries.PayToWallet);
            }
            else
            {
                return result.Failed(ApplicationMessages.ProcessFailed);
            }
            
        }
    }
}
