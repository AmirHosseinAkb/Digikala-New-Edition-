using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.RoleAgg;
using UserManagement.Domain.Transaction;
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
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
            modelBuilder.ApplyConfiguration(new TransactionTypeMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
