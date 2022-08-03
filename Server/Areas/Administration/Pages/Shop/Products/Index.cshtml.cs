using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Server.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage();
        }
    }
}
