using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application.Convertors;
using UserManagement.Application.Contracts.User.UserPanel;

namespace UserManagement.Application.Contracts.User
{
    public interface IUserApplication
    {
        OperationResult RegisterAndLogin(RegisterAndLoginCommand command);
        OperationResult Register(RegisterCommand command);
        OperationResult Login(LoginCommand command);
        OperationResult ForgetPassword(ForgetPasswordCommand command);
        OperationResult ResetPassword(ResetPasswordCommand command);
        bool ActiveAccount(string activationCode);
        bool IsExistByEmail(string email);
        void SignOut();

        #region UserPanel

        UserInformationsViewModel GetUserInformationsForShow(string email);

        #endregion
    }
}
