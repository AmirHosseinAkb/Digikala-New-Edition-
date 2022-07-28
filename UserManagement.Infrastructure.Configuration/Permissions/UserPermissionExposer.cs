using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;

namespace UserManagement.Infrastructure.Configuration.Permissions
{
    public class UserPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {"User",new List<PermissionDto>()
                    {
                        new PermissionDto("UsersList",100),
                        new PermissionDto("CreateUser",101),
                        new PermissionDto("EditUser",102),
                        new PermissionDto("DeleteUser",103),
                        new PermissionDto("DeletedUsersList",104),
                    }
                }
            };
        }
    }
}
