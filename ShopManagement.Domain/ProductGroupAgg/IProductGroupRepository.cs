using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductGroupAgg
{
    public interface IProductGroupRepository
    {
        List<ProductGroup> GetAll();
        List<ProductGroup> GetProductGroups();
        List<ProductGroup> GetSubProductGroups(long groupId);
    }
}
