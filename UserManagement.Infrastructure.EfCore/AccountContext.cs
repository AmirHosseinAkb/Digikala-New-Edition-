using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.RoleAgg;
using UserManagement.Domain.UserAgg;
using UserManagement.Infrastructure.EfCore.Mappings;

namespace UserManagement.Infrastructure.EfCore
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
