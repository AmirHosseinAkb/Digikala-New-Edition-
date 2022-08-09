using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductGroup;

namespace Server.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductGroupApplication _productGroupApplication;


        public IndexModel(IProductApplication productApplication, IProductGroupApplication productGroupApplication)
        {
            _productApplication = productApplication;
            _productGroupApplication = productGroupApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetCreate()
        {
            var groups = _productGroupApplication.GetGroups();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var primaryGroups = _productGroupApplication.GetSubGroups(int.Parse(groups.First().Value));
            ViewData["PrimaryGroups"] = new SelectList(primaryGroups, "Value", "Text");

            var secondaryGroups = _productGroupApplication.GetSubGroups(int.Parse(primaryGroups.First().Value));
            ViewData["SecondaryGroups"] = new SelectList(secondaryGroups, "Value", "Text");
            return Partial("./Create", new CreateProductCommand());
        }

        public IActionResult OnPostCreate(CreateProductCommand command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }
    }
}
