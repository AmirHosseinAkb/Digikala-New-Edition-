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
        private readonly IRoleRepository _reoleRepository;

        public RoleApplication(IRoleRepository reoleRepository)
        {
            _reoleRepository = reoleRepository;
        }
        public List<RoleViewModel> GetRoles()
        {
            return _reoleRepository.GetRoles().Select(r => new RoleViewModel()
            {
                RoleId = r.RoleId,
                RoleTitle = r.RoleTitle,
                Permissions = r.Permissions.Select(p=>p.PermissionTitle).ToList()
            }).ToList();
        }
    }
}
