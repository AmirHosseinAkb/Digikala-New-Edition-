using Digikala.Domain.UserManagement.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.UserManagement.Mappings
{
    public class PermissionMapping:IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(p => p.PermissionId);
            builder.Property(p => p.PermissionCode);
            builder.Property(p => p.RoleId);

            builder.HasOne<Role>(p => p.Role)
                .WithMany(r => r.Permissions).HasForeignKey(p => p.RoleId);

        }
    }
}
