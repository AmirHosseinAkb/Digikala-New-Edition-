using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts.Role;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Application
{
    public class RoleApplication:IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<RoleViewModel> GetRoles()
        {
            return _roleRepository.GetRoles().Select(r => new RoleViewModel()
            {
                RoleId = r.RoleId,
                RoleTitle = r.RoleTitle,
            }).ToList();
        }

        public void Create(CreateRoleCommand command)
        {
            var role = new Role(command.RoleTitle);
            var permissions = new List<Permission>();
            foreach (int permissionCode in command.PermissionCodes)
            {
                
            }
        }
    }
}
