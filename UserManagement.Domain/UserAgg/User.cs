using System.Security.AccessControl;
using UserManagement.Domain.RoleAgg;
using UserManagement.Domain.TransactionAgg;

namespace UserManagement.Domain.UserAgg
{
    public  class User
    {
        public long UserId { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get;private set; }
        public string? NationalNumber { get;private set; }
        public string? PhoneNumber { get;private set; }
        public DateTime? BirthDate { get;private set; }
        public DateTime RegisterDate { get; private set; }
        public string ActivationCode { get;private set; }
        public bool IsActive { get;private set; }
        public int VerificationCode { get;private set; }
        public byte RefundType { get;private set; } // 1: Pay To Account Number    2:Pay To Wallet
        public string? AccountNumber { get; private set; }
        public string AvatarName { get; private set; }
        public bool IsDeleted { get;private set; }
        public long RoleId { get;private set; }

        public Role Role { get;private set; }
        public List<TransactionAgg.Transaction> Transactions { get;private set; }
        

        protected User()
        {
            
        }

        public User(string activationCode,int verificationCode,long roleId,string? email=null,string? phoneNumber=null,string? password=null)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            ActivationCode = activationCode;
            VerificationCode = verificationCode;
            RoleId = roleId;
            IsActive = false;
            RegisterDate=DateTime.Now;
            AvatarName = "Default.png";
            RefundType = 0;
            IsDeleted = false;
            Password = password;
        }

        
        public void Activate()
        {
            IsActive = true;
        }

        public void ChangeActivationCode(string code)
        {
            ActivationCode = code;
        }

        public void ResetPassword(string password)
        {
            Password = password;
        }

        public void ChangeFullName(string firstName, string lastName)
        {
            FirstName=firstName;
            LastName=lastName;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void ChangeNationalNumber(string nationalNumber)
        {
            NationalNumber = nationalNumber;
        }

        public void ChangeBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void ChangeRefundType(byte refundType)
        {
            RefundType = refundType;
        }

        public void ChangeAccountNumber(string accountNumber)
        {
            AccountNumber=accountNumber;
        }
    }
}
