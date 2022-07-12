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
    }
}
