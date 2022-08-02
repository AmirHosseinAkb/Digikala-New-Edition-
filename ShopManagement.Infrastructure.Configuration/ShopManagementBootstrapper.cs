using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ShopContext>(options => 
                options.UseSqlServer(connectionString));
        }
    }
}
