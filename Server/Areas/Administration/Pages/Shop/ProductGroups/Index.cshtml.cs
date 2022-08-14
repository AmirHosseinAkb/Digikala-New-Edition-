using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductGroup;

namespace Server.Areas.Administration.Pages.Shop.ProductGroups
{
    public class IndexModel : PageModel
    {
        public IndexModel(IProductGroupApplication productGroupApplication)
        {
            _productGroupApplication = productGroupApplication;
        }
        private readonly IProductGroupApplication _productGroupApplication;
        public Tuple<List<ProductGroupViewModel>,int,int,int> ProductGroupVm { get; set; }
        public void OnGet(int pageId=1,string title="",int take=10)
        {
            if (take % 10 != 0)
                take = 10;
            ViewData["Take"] = take;
            ProductGroupVm = _productGroupApplication.GetProductGroupsForShow(pageId, title, take);
        }

        public IActionResult OnGetCreate(long? parentId)
        {
            var createGroupCommand = new CreateGroupCommand()
            {
                ParentId = parentId
            };
            return Partial("./Create",createGroupCommand);
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
