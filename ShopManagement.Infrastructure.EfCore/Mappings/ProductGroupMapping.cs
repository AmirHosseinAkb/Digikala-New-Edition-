using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Infrastructure.EfCore.Mappings
{
    public class ProductGroupMapping:IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.ToTable("ProductGroups");
            builder.HasKey(g => g.GroupdId);
            builder.Property(g => g.GroupTitle);
            builder.Property(g => g.ParentId);

            builder.HasMany(g=>g.ProductGroups).WithOne().HasForeignKey(g => g.GroupdId);

            builder.HasMany<Product>(g => g.Products).WithOne(p => p.ProductGroup)
                .HasForeignKey(p => p.GroupId);

            builder.HasMany<Product>(g => g.Products).WithOne(p => p.PrimaryProductGroup)
                .HasForeignKey(p => p.PrimaryGroupId);

            builder.HasMany<Product>(g => g.Products).WithOne(p => p.SecondaryProductGroup)
                .HasForeignKey(p => p.SecondaryGroupId);
        }
    }
}
