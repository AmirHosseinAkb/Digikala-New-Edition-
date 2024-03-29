﻿using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductColorAgg;
using Digikala.Domain.ShopManagement.ProductGroupAgg;
using Digikala.Domain.ShopManagement.ProductImageAgg;
using Digikala.Domain.ShopManagement.ProductInventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.ShopManagement.Mappings
{
    public class ProductMapping:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.GroupId);
            builder.Property(p => p.PrimaryGroupId).IsRequired(false);
            builder.Property(p => p.SecondaryGroupId).IsRequired(false);
            builder.Property(p => p.Title).HasMaxLength(300);
            builder.Property(p => p.OtherLangTitle).HasMaxLength(300);
            builder.Property(p => p.Description);
            builder.Property(p => p.Price);
            builder.Property(p => p.Tags).HasMaxLength(300);
            builder.Property(p => p.ImageName).HasMaxLength(300);
            builder.Property(p => p.CreationDate);
            builder.Property(p => p.IsDeleted);

            builder.HasOne<ProductGroup>(p => p.ProductGroup)
                .WithMany(g => g.Products).HasForeignKey(p => p.GroupId);

            builder.HasOne<ProductGroup>(p => p.PrimaryProductGroup).WithMany(g => g.PrimaryProducts)
                .HasForeignKey(p => p.PrimaryGroupId);

            builder.HasOne<ProductGroup>(p => p.SecondaryProductGroup).WithMany(g => g.SecondaryProducts)
                .HasForeignKey(p => p.SecondaryGroupId);

            builder.HasMany<ProductColor>(p => p.ProductColors).WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);

            builder.HasMany<ProductImage>(p => p.ProductImages).WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            builder.HasMany<ProductDetail>(p => p.ProductDetails).WithOne(d => d.Product)
                .HasForeignKey(d => d.ProductId);

            builder.HasOne<ProductInventory>(p => p.ProductInventory).WithOne(i => i.Product)
                .HasForeignKey<ProductInventory>(i => i.ProductId);

            builder.HasMany(p => p.InventoryHistories).WithOne(h => h.Product)
                .HasForeignKey(h => h.ProductId);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
