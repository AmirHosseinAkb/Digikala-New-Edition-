using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductGroupAgg
{
    public class ProductGroup
    {
        public long GroupdId { get;private set; }
        public string GroupTitle { get; private set; }
        public long? ParentId { get; private set; }
        public List<ProductGroup> ProductGroups { get; set; }
        public string ImageName { get; set; }

        public List<Product> Products { get; set; }
        public List<Product> PrimaryProducts { get; set; }
        public List<Product> SecondaryProducts { get; set; }

        protected ProductGroup()
        {
            
        }
        public ProductGroup(string groupTitle,long? parentId,string imageName)
        {
            GroupTitle=groupTitle;
            ParentId=parentId;
            ImageName = imageName;
        }
    }
}
