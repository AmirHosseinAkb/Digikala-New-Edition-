using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        List<RoleViewModel> GetRoles();
        void Create(CreateRoleCommand command);
        EditRoleCommand GetRoleForEdit(long roleId);
    }
}
