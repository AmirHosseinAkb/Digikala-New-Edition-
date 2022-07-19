using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Transaction;

namespace UserManagement.Infrastructure.EfCore.Mappings
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
                .HasForeignKey(t => t.TransactionId);

            #region SeedDatas

            builder.HasData(
                new TransactionType(1,"واریز"),
                new TransactionType(2,"برداشت")
            );

            #endregion
        }
    }
}
