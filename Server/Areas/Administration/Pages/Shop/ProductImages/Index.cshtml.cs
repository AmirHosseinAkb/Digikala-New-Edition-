using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductImage;

namespace Server.Areas.Administration.Pages.Shop.ProductImages
{
    public class IndexModel : PageModel
    {
        private readonly IProductImageApplication _productImageApplication;

        public IndexModel(IProductImageApplication productImageApplication)
        {
            _productImageApplication = productImageApplication;
        }
        public List<string> ProductImages { get; set; }
        public void OnGet(long productId)
        {
            ProductImages = _productImageApplication.GetProductImages(productId);
        }

        public IActionResult OnGetCreate(long productId)
        {
            return Partial("./Create");
        }
    }
}
