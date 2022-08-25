using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductColorAgg;
using Digikala.Domain.ShopManagement.ProductGroupAgg;
using Digikala.Domain.ShopManagement.ProductImageAgg;
using Digikala.Infrastructure.EfCore.ShopManagement.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Digikala.Infrastructure.EfCore.ShopManagement
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<GroupDetail> GroupDetails { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductGroupMapping());
            modelBuilder.ApplyConfiguration(new ProductImageMapping());
            modelBuilder.ApplyConfiguration(new ProductColorMapping());
            modelBuilder.ApplyConfiguration(new GroupDetailMapping());
            modelBuilder.ApplyConfiguration(new ProductDetailMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
