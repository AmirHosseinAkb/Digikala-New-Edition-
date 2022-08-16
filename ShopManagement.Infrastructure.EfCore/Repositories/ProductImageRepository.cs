using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductImageAgg;

namespace ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductImageRepository:IProductImageRepository
    {
        private readonly ShopContext _context;

        public ProductImageRepository(ShopContext context)
        {
            _context = context;
        }

        public List<ProductImage> GetProductImages(long productId)
        {
            return _context.ProductImages.Where(i => i.ProductId == productId).ToList();
        }

        public void Add(ProductImage Image)
        {
            _context.ProductImages.Add(Image);
            _context.SaveChanges();
        }
    }
}
