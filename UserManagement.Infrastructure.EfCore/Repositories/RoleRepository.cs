using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return _context.Roles.Include(r=>r.Permissions).ToList();
        }

        public Role GetRoleById(long roleId)
        {
            return _context.Roles.Find(roleId);
        }
    }
}
