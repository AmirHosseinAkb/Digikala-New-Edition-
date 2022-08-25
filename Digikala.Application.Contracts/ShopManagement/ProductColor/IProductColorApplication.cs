using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;

namespace Digikala.Application.Contracts.ShopManagement.ProductColor
{
    public interface IProductColorApplication
    {
        OperationResult Create(CreateColorCommand command);
        List<ProductColorViewModel> GetAll();
        void Delete(long colorId);
    }
}
