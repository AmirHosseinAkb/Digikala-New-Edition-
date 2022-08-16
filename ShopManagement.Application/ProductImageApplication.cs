using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductImage;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductImageAgg;

namespace ShopManagement.Application
{
    public class ProductImageApplication:IProductImageApplication
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;
        public ProductImageApplication(IProductImageRepository productImageRepository,IProductRepository productRepository)
        {
            _productImageRepository = productImageRepository;
            _productRepository = productRepository;
        }

        public List<string> GetProductImages(long productId)
        {
            return _productImageRepository.GetProductImages(productId).Select(i => i.ImageName).ToList();
        }

        public OperationResult Create(CreateImageCommand command)
        {
            var result = new OperationResult();
            var product = _productRepository.GetProductById(command.ProductId);
            if (product == null)
                return result.NullResult();

            if (command.ProductImage == null)
                return result.NullResult();
            var imageName = CodeGenerator.GenerateUniqName() + Path.GetExtension(command.ProductImage.FileName);
            var imagePath = Directories.ProductImageDirectory(imageName);
            using(var stream=new FileStream(imagePath,FileMode.Create))
                command.ProductImage.CopyTo(stream);
            var image = new ProductImage(command.ProductId, imageName);
            _productImageRepository.Add(image);
            return result.Succeeded();
        }
    }
}
