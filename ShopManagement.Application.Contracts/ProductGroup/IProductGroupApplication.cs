using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopManagement.Application.Contracts.ProductGroup
{
    public interface IProductGroupApplication
    {
        bool IsExistAnyGroup();
        List<SelectListItem> GetGroups();
        List<SelectListItem> GetSubGroups(long groupId);
    }
}
