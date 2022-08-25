using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductGroupAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.ShopManagement.Mappings
{
    public class ProductDetailMapping:IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetails");
            builder.HasKey(d => d.PD_Id);
            builder.Property(d=>d.ProductId);
            builder.Property(d=>d.DetailId);
            builder.Property(d=>d.DetailValue).IsRequired(false).HasMaxLength(500);

            builder.HasOne<Product>(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<GroupDetail>(d => d.GroupDetail).WithMany(g => g.ProductDetails)
                .HasForeignKey(d => d.DetailId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
