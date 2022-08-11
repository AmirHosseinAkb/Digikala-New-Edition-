﻿using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll(string title="",long groupId=0,long primaryGroupId=0,long secondaryGroupId=0)
        {
           IQueryable<Product> products = _context.Products;

            if(!string.IsNullOrWhiteSpace(title))
                products=products.Where(p=>p.Title.Contains(title));

            if(groupId!=0)
                products=products.Where(p=>p.GroupId==groupId);

            if(primaryGroupId!=0)
                products=products.Where(p=>p.PrimaryGroupId==primaryGroupId);

            if(secondaryGroupId!=0)
                products=products.Where(p=>p.SecondaryGroupId==secondaryGroupId);
            
            return products.ToList();
        }

        public bool IsExistProduct(string title)
        {
            return _context.Products.Any(p => p.Title == title);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
