using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digikala.Domain.ShopManagement.ProductColorAgg;
using Digikala.Domain.ShopManagement.ProductGroupAgg;
using Digikala.Domain.ShopManagement.ProductImageAgg;
using Digikala.Domain.ShopManagement.ProductInventoryAgg;

namespace Digikala.Domain.ShopManagement.ProductAgg
{
    public class Product
    {
        public long ProductId { get; private set; }
        public long GroupId { get; private set; }
        public long? PrimaryGroupId { get; private set; }
        public long? SecondaryGroupId { get;private set; }
        public string Title { get; private set; }
        public string OtherLangTitle { get; private set; }
        public string Description { get;private set; }
        public int Price { get; private set; }
        public string Tags { get; private set; }
        public string ImageName { get;private set; }
        public DateTime CreationDate { get;private set; }
        public bool IsDeleted { get;private set; }

        public ProductGroup ProductGroup { get;private set; }
        public ProductGroup PrimaryProductGroup { get;private set; }
        public ProductGroup SecondaryProductGroup { get;private set; }
        public ProductInventory ProductInventory { get; private set; }
        public List<ProductImage> ProductImages { get;private set; }
        public List<ProductColor> ProductColors { get;private set; }
        public List<ProductDetail> ProductDetails { get; private set; }
        public List<InventoryHistory> InventoryHistories { get; private set; }

        protected Product()
        {
            
        }

        public Product(long groupId, long? primaryGroupId, long? secondaryGroupId, string title, string description, int price
            , string otherLangTitle, string tags, string imageName)
        {
            GroupId = groupId;
            PrimaryGroupId = primaryGroupId;
            SecondaryGroupId = secondaryGroupId;
            Title = title;
            OtherLangTitle = otherLangTitle;
            Description = description;
            Price = price;
            Tags = tags;
            ImageName = imageName;
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }
        public void Edit(long groupId, long? primaryGroupId, long? secondaryGroupId, string title, string description, int price
            , string otherLangTitle, string tags, string imageName)
        {
            GroupId = groupId;
            PrimaryGroupId = primaryGroupId;
            SecondaryGroupId = secondaryGroupId;
            Title = title;
            OtherLangTitle = otherLangTitle;
            Description = description;
            Price = price;
            Tags = tags;
            ImageName = imageName;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
