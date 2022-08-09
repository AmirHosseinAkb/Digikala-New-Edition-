using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repositories;
using ShopManagement.Application.Contracts.ProductGroup;
using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductApplication,ProductApplication>();
            services.AddScoped<IProductGroupApplication,ProductGroupApplication>();
            services.AddScoped<IProductGroupRepository,ProductGroupRepository>();
            services.AddDbContext<ShopContext>(options => 
                options.UseSqlServer(connectionString));
        }
    }
}
