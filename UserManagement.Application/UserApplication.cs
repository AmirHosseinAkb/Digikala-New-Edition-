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
        private readonly  IViewRenderService _viewRenderService;
        private readonly IEmailService _emailService;
        private readonly  IPasswordHasher _passwordHasher;

        public UserApplication(IUserRepository userRepository,IViewRenderService viewRenderService, IEmailService emailService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _viewRenderService = viewRenderService;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Register(RegisterCommand command)
        {
            var operation = new OperationResult();
            if (_userRepository.IsExistByEmail(command.Email))
                return operation.Failed(ApplicationMessages.DuplicatedEmail);

            var activationCode = CodeGenerator.GenerateUniqName();
            var hashedPassword = _passwordHasher.HashMD5(command.Password);
            var user = new User(activationCode, CodeGenerator.GenerateRandomNumber()
                    , 3, email: command.Email,password:hashedPassword);

            var body=_viewRenderService.RenderToStringAsync
                ("_ActivationEmailBody",new ActivationEmailViewModel(){Email = command.Email,ActivationCode = activationCode}); // Email Body
            _emailService.SendEmail(command.Email,DataDictionaries.ActiveAccount,body); //Send Email
            _userRepository.Add(user);

            return operation.Succeeded();
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
    }
}
