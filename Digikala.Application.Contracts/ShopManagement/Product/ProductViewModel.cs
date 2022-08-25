using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digikala.Application.Contracts.ShopManagement.Product
{
    public class ProductViewModel
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public string CreationDate { get; set; }
    }
}
