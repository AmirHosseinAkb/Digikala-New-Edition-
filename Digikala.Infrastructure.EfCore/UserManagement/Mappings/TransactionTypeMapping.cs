using Digikala.Domain.UserManagement.TransactionAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digikala.Infrastructure.EfCore.UserManagement.Mappings
{
    internal class TransactionTypeMapping:IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("TransactionTypes");
            builder.HasKey(t => t.TypeId);
            builder.Property(t => t.Type).HasMaxLength(200);

            builder.HasMany<Transaction>(t => t.Transactions)
                .WithOne(t => t.TransactionType)
                .HasForeignKey(t => t.TypeId);

            #region SeedDatas

            builder.HasData(
                new TransactionType(1,"واریز"),
                new TransactionType(2,"برداشت")
            );

            #endregion
        }
    }
}
