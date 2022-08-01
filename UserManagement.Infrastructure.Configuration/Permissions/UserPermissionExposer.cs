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
                        new PermissionDto("UsersList",UserPermissions.UsersList),
                        new PermissionDto("CreateUser",UserPermissions.CreateUser),
                        new PermissionDto("EditUser",UserPermissions.EditUser),
                        new PermissionDto("DeleteUser",UserPermissions.DeleteUser),
                        new PermissionDto("DeletedUsersList",UserPermissions.DeletedUsersList),
                        new PermissionDto("Return User",UserPermissions.ReturnUser)
                    }
                }
            };
        }
    }
}
