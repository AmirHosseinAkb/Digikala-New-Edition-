using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductGroupAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.ShopManagement.Mappings
{
    public class GroupDetailMapping:IEntityTypeConfiguration<GroupDetail>
    {
        public void Configure(EntityTypeBuilder<GroupDetail> builder)
        {
            builder.ToTable("GroupDetails");
            builder.HasKey(d => d.DetailId);
            builder.Property(d=>d.GroupId);
            builder.Property(d => d.DetailTitle).HasMaxLength(200);

            builder.HasOne<ProductGroup>(d => d.ProductGroup).WithMany(g => g.GroupDetails)
                .HasForeignKey(d => d.GroupId);

            builder.HasMany<ProductDetail>(d => d.ProductDetails).WithOne(p => p.GroupDetail)
                .HasForeignKey(p=>p.DetailId);

        }
    }
}
