using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductImage
{
    public interface IProductImageApplication
    {
        List<string> GetProductImages(long productId);
        OperationResult Create(CreateImageCommand command);
    }
}
