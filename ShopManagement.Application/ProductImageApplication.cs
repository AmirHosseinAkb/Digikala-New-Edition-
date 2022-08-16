using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contracts.ProductImage;
using ShopManagement.Domain.ProductImageAgg;

namespace ShopManagement.Application
{
    public class ProductImageApplication:IProductImageApplication
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageApplication(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public List<string> GetProductImages(long productId)
        {
            return _productImageRepository.GetProductImages(productId).Select(i => i.ImageName).ToList();
        }
    }
}
