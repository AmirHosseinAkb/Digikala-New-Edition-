using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductGroup;

namespace Server.Areas.Administration.Pages.Shop.ProductGroups
{
    public class IndexModel : PageModel
    {
        private readonly IProductGroupApplication _productGroupApplication;

        public IndexModel(IProductGroupApplication productGroupApplication)
        {
            _productGroupApplication = productGroupApplication;
        }
        public void OnGet()
        {
        }

        public IActionResult OnGetCreate()
        {
            return RedirectToPage();
        }
    }
}
