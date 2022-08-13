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
            string produtImage = ProductImageName.DefaultName;

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

        public EditProductCommand GetProductForEdit(long productId)
        {
            var product = _productRepository.GetProductById(productId);
            return new EditProductCommand()
            {
                Title = product.Title,
                Description = product.Description,
                GroupId = product.GroupId,
                ImageName = product.ImageName,
                OtherLangTitle = product.OtherLangTitle,
                Price = product.Price,
                Tags = product.Tags,
                PrimaryGroupId = product.PrimaryGroupId,
                SecondaryGroupId = product.SecondaryGroupId
            };
        }

        public OperationResult Edit(EditProductCommand command)
        {
            var result = new OperationResult();
            var product = _productRepository.GetProductById(command.ProductId);
            if (product.Title != command.Title)
            {
                if (_productRepository.IsExistProduct(command.Title))
                    return result.Failed(ApplicationMessages.DuplicatedProduct);
            }

            var productImage = product.ImageName;
            if (command.ProductImage != null)
            {
                string imagePath = "";
                if (product.ImageName != ProductImageName.DefaultName)
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "Products",
                        "Images",
                        product.ImageName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                productImage = CodeGenerator.GenerateUniqName() + Path.GetExtension(command.ProductImage.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Products",
                    "Images",
                    productImage);
                using (var stream=new FileStream(imagePath,FileMode.Create))
                {
                    command.ProductImage.CopyTo(stream);
                }
            }
            product.Edit(command.GroupId,command.PrimaryGroupId,command.SecondaryGroupId,command.Title
                ,command.Description,command.Price,command.OtherLangTitle,command.Tags,productImage);
            _productRepository.SaveChanges();
            return result.Succeeded();
        }

        public DeleteProductCommand GetProductForDelete(long productId)
        {
            var product = _productRepository.GetProductWithGroups(productId);
            return new DeleteProductCommand()
            {
                ProductId = product.ProductId,
                Title = product.Title,
                GroupName = product.ProductGroup.GroupTitle,
                PrimaryGroupName = product.PrimaryProductGroup.GroupTitle,
                SecondaryGroupName = product.SecondaryProductGroup.GroupTitle,
                ImageName = product.ImageName
            };
        }

        public OperationResult Delete(long productId)
        {
            var result = new OperationResult();
            if (productId == 0)
                return result.Failed(ApplicationMessages.RecordNotFound);
            var product = _productRepository.GetProductById(productId);
            if (product == null)
                return result.NullResult();
            product.Delete();
            _productRepository.SaveChanges();
            return result.Succeeded();
        }

        public Tuple<List<ProductViewModel>,int,int,int> GetProducts(int pageId=1,string title="",long groupId=0,long primaryGroupId=0,long secondaryGroupId=0,int take=0)
        {
            var products=_productRepository.GetAll(title,groupId,primaryGroupId,secondaryGroupId).Select(p=>new ProductViewModel()
            {
                ProductId = p.ProductId,
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
