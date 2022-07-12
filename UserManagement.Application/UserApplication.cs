using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application.Convertors;
using _01_Framework.Application.Convertors;
using UserManagement.Application.Contracts.User;
using UserManagement.Domain.UserAgg;

namespace UserManagement.Application
{
    public class UserApplication:IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OperationResult Register(RegisterCommand command)
        {
            var operation = new OperationResult();
            

            if (command.EmailOrPhone.IsEmail())
            {
                if (_userRepository.IsExistByEmail(EmailConvertor.FixEmail(command.EmailOrPhone)))
                    return operation.Failed(ApplicationMessages.DuplicatedEmail);
                var user = new User(CodeGenerator.GenerateUniqName(), CodeGenerator.GenerateRandomNumber()
                    , 3,command.EmailOrPhone);
                return operation.Succeeded();
            }
            else if(command.EmailOrPhone.IsPhoneNumber())
            {
                if (_userRepository.IsExistByPhoneNumber(command.EmailOrPhone))
                    return operation.Failed(ApplicationMessages.DuplicatedPhone);
                var user = new User(CodeGenerator.GenerateUniqName(), CodeGenerator.GenerateRandomNumber()
                    , 3,null,command.EmailOrPhone);
                return operation.Succeeded();
            }
            return operation.Failed(ApplicationMessages.InvalidEmailOrPhoneNumber);
        }

        public bool IsExistByEmail(string email)
        {
            return _userRepository.IsExistByEmail(email);
        }
    }
}
