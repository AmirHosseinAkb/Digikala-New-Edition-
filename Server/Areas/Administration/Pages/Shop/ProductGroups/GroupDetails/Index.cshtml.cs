using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductGroup;

namespace Server.Areas.Administration.Pages.Shop.ProductGroups.GroupDetails
{
    public class IndexModel : PageModel
    {
        private readonly IProductGroupApplication _productGroupApplication;

        public IndexModel(IProductGroupApplication productGroupApplication)
        {
            _productGroupApplication = productGroupApplication;
        }

        [BindProperty]
        public CreateGroupDetailCommand command { get; set; }
        public void OnGet(long groupId)
        {
        }

        public IActionResult OnPostCreate()
        {
            return null;
        }
    }
}
