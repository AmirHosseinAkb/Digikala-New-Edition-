using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.UserAgg;

namespace UserManagement.Infrastructure.EfCore.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AccountContext _context;

        public UserRepository(AccountContext context)
        {
            _context = context;
        }
        public bool IsExistByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistByPhoneNumber(string phoneNumber)
        {
            return _context.Users.Any(u => u.PhoneNumber == phoneNumber.Replace(" ", ""));
        }
    }
}
