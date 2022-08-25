using _01_Framework.Application;
using Digikala.Application.Contracts.ShopManagement.ProductImage;
using Digikala.Domain.ShopManagement.ProductAgg;
using Digikala.Domain.ShopManagement.ProductImageAgg;

namespace Digikala.Application.ShopManagement
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

        public List<ProductImageViewModel> GetProductImages(long productId)
        {
            return _productImageRepository.GetProductImages(productId)
                .Select(i => new ProductImageViewModel()
                {
                    ImageId = i.ImageId,
                    ProductId = i.ProductId,
                    ImageName = i.ImageName
                }).ToList();
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

        public OperationResult Delete(long imageId)
        {
            var result = new OperationResult();
            var image = _productImageRepository.GetById(imageId);
            if (image == null)
                return result.NullResult();
            _productImageRepository.Delete(image);
            var imagePath = Directories.ProductImageDirectory(image.ImageName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
            return result.Succeeded();
        }
    }
}
