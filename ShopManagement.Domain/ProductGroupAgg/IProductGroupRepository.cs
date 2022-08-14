namespace ShopManagement.Domain.ProductGroupAgg
{
    public interface IProductGroupRepository
    {
        List<ProductGroup> GetAll();
        List<ProductGroup> GetProductGroups(long? groupId);
        void Add(ProductGroup group);
        bool IsExistGroup(string title);

    }
}
