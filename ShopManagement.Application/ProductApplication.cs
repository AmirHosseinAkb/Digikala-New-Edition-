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

            if (command.ProductImage != null)
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
            _productRepository.AddProduct(product);
            return result.Succeeded();
        }

        public Tuple<List<ProductViewModel>,int,int,int> GetProducts(int pageId=1,string title="",long groupId=0,long primaryGroupId=0,long secondaryGroupId=0,int take=0)
        {
            var products=_productRepository.GetAll(title,groupId,primaryGroupId,secondaryGroupId).Select(p=>new ProductViewModel()
            {
                Title = p.Title,
                ImageName=p.ImageName,
                CreationDate=p.CreationDate.ToShamsi(),
                Price=p.Price
            }).ToList();

            var pageCount=products.Count()/take;

            if(products.Count()%take!=0)
                pageCount++;

            var skip=(pageId-1)*take;

            return Tuple.Create(products,pageId,pageCount,take);
        }
    }
}
