using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }
        public bool IsExistProduct(string title)
        {
            return _context.Products.Any(p => p.Title == title);
        }
    }
}
