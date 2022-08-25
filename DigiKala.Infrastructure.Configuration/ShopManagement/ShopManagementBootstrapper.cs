using Digikala.Application.Contracts.ShopManagement.Product;
using Digikala.Application.Contracts.ShopManagement.ProductColor;
using Digikala.Application.Contracts.ShopManagement.ProductGroup;
using Digikala.Application.Contracts.ShopManagement.ProductImage;
using Digikala.Application.ShopManagement;
using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductColorAgg;
using Digikala.Domain.ShopManagement.ProductGroupAgg;
using Digikala.Domain.ShopManagement.ProductImageAgg;
using Digikala.Infrastructure.EfCore.ShopManagement;
using Digikala.Infrastructure.EfCore.ShopManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Digikala.Infrastructure.Configuration.ShopManagement
{
    public class ShopManagementBootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductApplication,ProductApplication>();
            services.AddScoped<IProductGroupApplication,ProductGroupApplication>();
            services.AddScoped<IProductGroupRepository,ProductGroupRepository>();
            services.AddScoped<IProductColorApplication, ProductColorApplication>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductImageApplication, ProductImageApplication>();
            services.AddDbContext<ShopContext>(options => 
                options.UseSqlServer(connectionString));
        }
    }
}
