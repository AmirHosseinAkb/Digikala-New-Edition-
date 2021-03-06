using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.UserAgg
{
    public interface IUserRepository
    {
        bool IsExistByEmail(string email);
        bool IsExistByPhoneNumber(string phoneNumber);
        void Add(User user);
        User GetByActivationCode(string activationCode);
        User GetUserForLogin(string email,string password);
        User GetUserByEmail(string email);
        User GetUserById(long id);
        long GetUserWalletBalance(long userId);
        List<User> GetUsers();
        List<User> GetUsers(string fullName = "", string email = "", string phoneNumber = "");
        void SaveChanges();
    }
}
