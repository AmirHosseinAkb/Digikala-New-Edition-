using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace Server.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetCreate()
        {

            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreateProductCommand command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }
    }
}
