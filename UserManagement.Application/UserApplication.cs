using _01_Framework.Application;
using _01_Framework.Application.Convertors;
using _01_Framework.Application.Email;
using _01_Framework.Resources;
using UserManagement.Application.Contracts.User;
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
            var authVm = new AuthenticationViewModel(user.UserId, user.RoleId, user.Email!);
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
                new EmailViewModel() {Email = command.Email, ActivationCode = user.ActivationCode});
            _emailService.SendEmail(command.Email,DataDictionaries.ResetPassword,body);
            return result.Succeeded();
        }

        public OperationResult ResetPassword(ResetPasswordCommand command)
        {
            var result = new OperationResult();
            var user = _userRepository.GetByActivationCode(command.ActivationCode);
            if(user==null)
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
    }
}
