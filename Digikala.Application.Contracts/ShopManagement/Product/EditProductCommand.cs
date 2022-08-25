using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digikala.Application.Contracts.ShopManagement.Product
{
    public class EditProductCommand:CreateProductCommand
    {
        public long ProductId { get; set; }
        public string? ImageName { get; set; }
    }
}
