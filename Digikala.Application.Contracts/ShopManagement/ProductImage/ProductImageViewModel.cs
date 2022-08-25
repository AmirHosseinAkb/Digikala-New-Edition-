using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digikala.Application.Contracts.ShopManagement.ProductImage
{
    public class ProductImageViewModel
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public string ImageName { get; set; }
    }
}
