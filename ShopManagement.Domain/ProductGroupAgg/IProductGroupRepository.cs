namespace ShopManagement.Domain.ProductGroupAgg
{
    public interface IProductGroupRepository
    {
        List<ProductGroup> GetAll();
        List<ProductGroup> GetProductGroups();
        List<ProductGroup> GetSubProductGroups(long groupId);
    }
}
