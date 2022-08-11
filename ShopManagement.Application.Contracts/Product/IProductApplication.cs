using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        Tuple<List<ProductViewModel>,int,int,int> GetProducts(int pageId=1,string title="",long groupId=0,long primaryGroupId=0,long secondaryGroupId=0,int take=0);
        OperationResult Create(CreateProductCommand command);
    }
}
