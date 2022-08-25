using Digikala.Domain.UserManagement.TransactionAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.UserManagement.Mappings
{
    public class TransactionMapping:IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(t => t.TransactionId);
            builder.Property(t => t.UserId);
            builder.Property(t=>t.TypeId);
            builder.Property(t => t.Amount);
            builder.Property(t => t.CreationDate);
            builder.Property(t => t.Description).HasMaxLength(200);
            builder.Property(t => t.IsSucceeded);

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);

            builder.HasOne(t => t.TransactionType)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.TypeId);
        }
    }
}
