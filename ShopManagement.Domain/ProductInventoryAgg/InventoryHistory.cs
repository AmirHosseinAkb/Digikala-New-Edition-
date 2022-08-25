using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductInventoryAgg
{
    public class InventoryHistory
    {
        public long HistoryId { get; private set; }
        public long ProductId { get;private set; }
        public int Count { get;private set; }
        public DateTime Date { get;private set; }

        public Product Product { get;private set; }

        protected InventoryHistory()
        {
            
        }

        public InventoryHistory(long productId, int count, DateTime date)
        {
            ProductId = productId;
            Count = count;
            Date = date;
        }
    }
}
