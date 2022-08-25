using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductInventoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Mappings
{
    public class InventoryHistoryMapping:IEntityTypeConfiguration<InventoryHistory>
    {
        public void Configure(EntityTypeBuilder<InventoryHistory> builder)
        {
            builder.ToTable("InventoryHistories");
        }
    }
}
