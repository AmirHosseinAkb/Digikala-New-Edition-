using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digikala.Domain.ShopManagement.ProductAgg;

namespace Digikala.Domain.ShopManagement.ProductInventoryAgg
{
    public class ProductInventory
    {
        public long InventoryId { get; private set; }
        public int InventoryCount { get;private set; }
        public long ProductId { get;private set; }
        public Product Product { get;private set; }

        protected ProductInventory()
        {
            
        }

        public ProductInventory(long productId, int inventoryCount)
        {
            ProductId = productId;
            InventoryCount = inventoryCount;
        }
    }
}
