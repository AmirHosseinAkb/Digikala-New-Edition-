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
        string ConfirmUserFullName(string email,FullNameCommand command);
        OperationResult ConfirmUserEmail(string email,EmailCommand command);
        OperationResult ConfirmUserPhoneNumber(string email,PhoneNumberCommand command);
        string ConfirmUserNationalNumber(string email,NationalNumberCommand command);
        OperationResult ConfirmUserBirthDate(string email,BirthDateCommand command);
        OperationResult ConfirmUserPassword(string email,PasswordCommand command);
        OperationResult ConfirmUserRefundType(string email,RefundCommand command);

        #endregion
    }
}
