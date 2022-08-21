using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductGroup;

namespace Server.Areas.Administration.Pages.Shop.Products.ProductDetails
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public void OnGet(long productId)
        {

        }

        public IActionResult OnPost(long productId,Dictionary<int,string> details)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return null;
        }
    }
}
