using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductColorAgg;
using ShopManagement.Domain.ProductGroupAgg;
using ShopManagement.Domain.ProductImageAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product
    {
        public long ProductId { get; private set; }
        public long GroupId { get; private set; }
        public long? PrimaryGroupId { get; private set; }
        public long? SecondaryGroupId { get;private set; }
        public string Title { get; private set; }
        public string Description { get;private set; }
        public string ShortDescription { get; private set; }
        public int Price { get; private set; }
        public string Tags { get; private set; }
        public string ImageName { get;private set; }
        public DateTime CreationDate { get;private set; }
        public bool IsDeleted { get;private set; }

        public ProductGroup ProductGroup { get;private set; }
        public ProductGroup PrimaryProductGroup { get;private set; }
        public ProductGroup SecondaryProductGroup { get;private set; }
        public List<ProductImage> ProductImages { get;private set; }
        public List<ProductColor> ProductColors { get;private set; }

        protected Product()
        {
            
        }

        public Product(long groupId, long? primaryGroupId, long? secondaryGroupId, string title, string description, int price
            , string shortDescription, string tags, string imageName)
        {
            GroupId = groupId;
            PrimaryGroupId = primaryGroupId;
            SecondaryGroupId = secondaryGroupId;
            Title = title;
            Description = description;
            Price = price;
            ShortDescription = shortDescription;
            Tags = tags;
            ImageName = imageName;
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
