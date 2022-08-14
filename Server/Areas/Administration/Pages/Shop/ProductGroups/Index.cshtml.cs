using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreateGroupCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = _productGroupApplication.CreateGroup(command);
            return new JsonResult(result);
        }
    }
}
