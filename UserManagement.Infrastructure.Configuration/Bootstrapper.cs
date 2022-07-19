using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application;
using UserManagement.Application.Contracts.User;
using UserManagement.Domain.Transaction;
using UserManagement.Domain.UserAgg;
using UserManagement.Infrastructure.EfCore;
using UserManagement.Infrastructure.EfCore.Repositories;

namespace UserManagement.Infrastructure.Configuration
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserApplication,UserApplication>();
            services.AddScoped<ITransactionRepository,TransactionRepository>();
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
