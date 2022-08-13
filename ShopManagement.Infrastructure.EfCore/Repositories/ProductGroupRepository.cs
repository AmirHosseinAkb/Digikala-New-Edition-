﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductGroupRepository:IProductGroupRepository
    {
        private readonly ShopContext _context;

        public ProductGroupRepository(ShopContext context)
        {
            _context = context;
        }

        public List<ProductGroup> GetAll()
        {
            return _context.ProductGroups.ToList();
        }

        public List<ProductGroup> GetProductGroups()
        {
            return _context.ProductGroups.Where(g=>g.ParentId==null).ToList();
        }

        public List<ProductGroup> GetSubProductGroups(long groupId)
        {
            return _context.ProductGroups.Where(g => g.ParentId == groupId).ToList();
        }

    }
}
