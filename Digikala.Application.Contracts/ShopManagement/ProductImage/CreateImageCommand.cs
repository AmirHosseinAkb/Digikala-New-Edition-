using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Digikala.Application.Contracts.ShopManagement.ProductImage
{
    public class CreateImageCommand
    {
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public IFormFile ProductImage { get; set; }
    }
}
