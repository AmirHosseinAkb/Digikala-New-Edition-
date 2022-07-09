using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.RoleAgg;

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
        public byte RefundType { get;private set; } // 0: Wallet 1:Pay to bank account
        public string AvatarName { get; private set; }
        public bool IsDeleted { get;private set; }
        public long RoleId { get;private set; }

        public Role Role { get;private set; }


        protected User()
        {
            
        }

        public User(string activationCode,int verificationCode,long roleId)
        {
            ActivationCode = activationCode;
            VerificationCode = verificationCode;
            RoleId = roleId;
            IsActive = false;
            RegisterDate=DateTime.Now;
            AvatarName = "Default.png";
            RefundType = 0;
            IsDeleted = false;
        }
    }
}
