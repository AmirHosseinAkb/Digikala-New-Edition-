using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopManagement.Application.Contracts.ProductGroup
{
    public interface IProductGroupApplication
    {
        List<SelectListItem> GetGroups();
        List<SelectListItem> GetSubGroups(long groupId);
    }
}
