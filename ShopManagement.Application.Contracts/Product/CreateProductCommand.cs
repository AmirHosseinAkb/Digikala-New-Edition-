using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProductCommand
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long GroupId { get; set; }

        public long? PrimaryGroupId { get; set; }

        public long? SecondaryGroupId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLenght)]

        public string Title { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(200,ErrorMessage = ValidationMessages.MaxLenght)]
        public string ShortDescription { get; set; }

        public int Price { get; set; }
        public string Tags { get; set; }
        public string ImageName { get; set; }
    }
}
