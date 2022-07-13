using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application.Convertors;

namespace UserManagement.Application.Contracts.User
{
    public interface IUserApplication
    {
        OperationResult Register(RegisterCommand command);
        bool ActiveAccount(string activationCode);
        bool IsExistByEmail(string email);
    }
}
