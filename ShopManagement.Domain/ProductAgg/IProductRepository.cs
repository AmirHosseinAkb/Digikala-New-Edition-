using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository
    {
        List<Product> GetAll(string title="",long groupId=0,long primaryGroupId=0,long secondaryGroupId=0);
        bool IsExistProduct(string title);
        void AddProduct(Product product);
        Product GetProductById(long productId);
        Product GetProductWithGroups(long productId);
        void SaveChanges();
        Product GetProductByGroupId(long groupId);

        #region ProductDetail

        List<Product> GetProductsByGroupId(long groupId);
        void AddProductDetails(GroupDetail detail);
        void AddProductDetails(Product product);

        #endregion
    }
}
