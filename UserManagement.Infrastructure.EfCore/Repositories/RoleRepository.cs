using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Infrastructure.EfCore.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context)
        {
            _context = context;
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
