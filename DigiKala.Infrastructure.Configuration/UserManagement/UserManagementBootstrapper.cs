using _01_Framework.Infrastructure;
using Digikala.Applicaion.UserManagement.Application;
using Digikala.Application.Contracts.UserManagement.Role;
using Digikala.Application.Contracts.UserManagement.Transaction;
using Digikala.Application.Contracts.UserManagement.User;
using Digikala.Domain.UserManagement.RoleAgg;
using Digikala.Domain.UserManagement.TransactionAgg;
using Digikala.Domain.UserManagement.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Digikala.Infrastructure.Configuration.UserManagement.Permissions;
using Digikala.Infrastructure.EfCore.UserManagement;
using Digikala.Infrastructure.EfCore.UserManagement.Repositories;

namespace Digikala.Infrastructure.Configuration.UserManagement
{
    public class UserManagementBootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserApplication,UserApplication>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IRoleApplication,RoleApplication>();
            services.AddScoped<ITransactionRepository,TransactionRepository>();
            services.AddScoped<ITransactionApplication,TransactionApplication>();
            services.AddTransient<IPermissionExposer,UserPermissionExposer>();
            services.AddTransient<IPermissionExposer,RolePermissionExposer>();
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
