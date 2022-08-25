using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductImageAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.ShopManagement.Mappings
{
    public class ProductImageMapping:IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(i => i.ImageId);
            builder.Property(i => i.ImageName);
            builder.Property(i => i.ProductId);

            builder.HasOne<Product>(i => i.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(i => i.ProductId);

        }
    }
}
