using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductInventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.ShopManagement.Mappings
{
    public class ProductInventoryMapping:IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.ToTable("ProductInventories");
            builder.HasKey(i => i.InventoryId);
            builder.Property(i=>i.ProductId);
            builder.Property(i => i.InventoryCount);
            builder.HasOne<Product>(i => i.Product).WithOne(p => p.ProductInventory)
                .HasForeignKey<ProductInventory>(i => i.ProductId);
        }
    }
}
