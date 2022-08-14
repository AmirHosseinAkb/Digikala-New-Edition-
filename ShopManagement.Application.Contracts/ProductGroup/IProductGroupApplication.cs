using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopManagement.Application.Contracts.ProductGroup
{
    public interface IProductGroupApplication
    {
        bool IsExistAnyGroup();
        List<SelectListItem> GetGroups(long? groupId);
        OperationResult CreateGroup(CreateGroupCommand command);
        
        Tuple<List<ProductGroupViewModel> , int, int, int> GetProductGroupsForShow(int pageId = 1, string title = "",
            int take = 10);
    }
}
