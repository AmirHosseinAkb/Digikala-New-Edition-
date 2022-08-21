using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProductDetailCommand
    {
        public long ProductId { get; set; }
        public long DetailId { get; set; }
        public string DetailValue { get; set; }

    }
}
