using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;
using Org.BouncyCastle.Asn1.Misc;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductCommand command)
        {
            var result=new OperationResult();
            if (_productRepository.IsExistProduct(command.Title))
                return result.Failed(ApplicationMessages.DuplicatedProduct);
            string produtImage = "Product.png";

            if (command.Description != null)
            {
                produtImage = CodeGenerator.GenerateUniqName() + Path.GetExtension(command.ProductImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Products",
                    "Images",
                    produtImage);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    command.ProductImage.CopyTo(stream);
                }
            }

            var product = new Product(command.GroupId, command.PrimaryGroupId, command.SecondaryGroupId, command.Title,
                command.Description, command.Price, command.OtherLangTitle, command.Tags, produtImage);
            return result.Succeeded();
        }
    }
}
