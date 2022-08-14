namespace ShopManagement.Domain.ProductGroupAgg
{
    public interface IProductGroupRepository
    {
        List<ProductGroup> GetAll();
        List<ProductGroup> GetProductGroups(long? groupId);
        List<ProductGroup> GetProductGroupsForShow(string title = "");
        void Add(ProductGroup group);
        bool IsExistGroup(string title);

    }
}
