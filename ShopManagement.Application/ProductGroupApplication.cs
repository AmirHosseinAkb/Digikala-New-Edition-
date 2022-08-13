using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductGroup;
using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Application
{
    public class ProductGroupApplication:IProductGroupApplication
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupApplication(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public bool IsExistAnyGroup()
        {
            if (_productGroupRepository.GetAll().Count == 0)
                return false;
            return true;
        }

        public List<SelectListItem> GetGroups()
        {
            return _productGroupRepository.GetProductGroups().Select(g => new SelectListItem()
            {
                Text = g.GroupTitle,
                Value = g.GroupdId.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetSubGroups(long groupId)
        {
            return _productGroupRepository.GetSubProductGroups(groupId).Select(g => new SelectListItem()
            {
                Text = g.GroupTitle,
                Value = g.GroupdId.ToString()
            }).ToList();
        }
    }
}
