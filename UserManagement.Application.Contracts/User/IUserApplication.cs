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

        UserInformationsViewModel GetUserInformationsForShow();
        string ConfirmUserFullName(FullNameCommand command);
        OperationResult ConfirmUserEmail(EmailCommand command);
        OperationResult ConfirmUserPhoneNumber(PhoneNumberCommand command);
        string ConfirmUserNationalNumber(NationalNumberCommand command);
        string ConfirmUserBirthDate(BirthDateCommand command);
        OperationResult ConfirmUserPassword(PasswordCommand command);
        OperationResult ConfirmUserRefundType(RefundCommand command);

        #endregion
    }
}
