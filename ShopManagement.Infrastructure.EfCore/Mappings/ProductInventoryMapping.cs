using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductInventoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Mappings
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
