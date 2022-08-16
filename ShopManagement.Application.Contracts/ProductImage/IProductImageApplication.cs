using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductImage
{
    public interface IProductImageApplication
    {
        List<string> GetProductImages(long productId);
    }
}
