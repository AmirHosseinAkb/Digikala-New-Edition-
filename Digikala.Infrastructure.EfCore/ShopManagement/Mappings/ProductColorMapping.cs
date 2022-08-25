using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductColorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.ShopManagement.Mappings
{
    public class ProductColorMapping:IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.ToTable("ProductColors");
            builder.HasKey(c => c.ColorId);
            builder.Property(c=>c.ProductId);
            builder.Property(c=>c.ColorCode);
            builder.Property(c=>c.ColorName);

            builder.HasOne<Product>(c => c.Product).WithMany(p => p.ProductColors)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
