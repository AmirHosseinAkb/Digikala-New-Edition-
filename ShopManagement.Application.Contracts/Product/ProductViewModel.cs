using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public string CreationDate { get; set; }
    }
}
