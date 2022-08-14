using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductGroupRepository:IProductGroupRepository
    {
        private readonly ShopContext _context;

        public ProductGroupRepository(ShopContext context)
        {
            _context = context;
        }

        public List<ProductGroup> GetAll()
        {
            return _context.ProductGroups.ToList();
        }

        public List<ProductGroup> GetProductGroups()
        {
            return _context.ProductGroups.Where(g=>g.ParentId==null).ToList();
        }

        public List<ProductGroup> GetSubProductGroups(long groupId)
        {
            return _context.ProductGroups.Where(g => g.ParentId == groupId).ToList();
        }

        public void Add(ProductGroup group)
        {
            _context.ProductGroups.Add(group);
            _context.SaveChanges();
        }

        public bool IsExistGroup(string title)
        {
            return _context.ProductGroups.Any(g => g.ParentId==null &&g.GroupTitle == title);
        }
    }
}
