using Digikala.Domain.UserManagement.RoleAgg;
using Digikala.Domain.UserManagement.TransactionAgg;
using Digikala.Domain.UserManagement.UserAgg;
using Microsoft.EntityFrameworkCore;
using Digikala.Infrastructure.EfCore.UserManagement.Mappings;

namespace Digikala.Infrastructure.EfCore.UserManagement
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
            modelBuilder.ApplyConfiguration(new TransactionTypeMapping());
            modelBuilder.ApplyConfiguration(new PermissionMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
