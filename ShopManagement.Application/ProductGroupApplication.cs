using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductGroup;
using ShopManagement.Domain.ProductGroupAgg;

namespace ShopManagement.Application
{
    public class ProductGroupApplication:IProductGroupApplication
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupApplication(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public bool IsExistAnyGroup()
        {
            if (_productGroupRepository.GetAll().Count == 0)
                return false;
            return true;
        }

        public List<SelectListItem> GetGroups(long? groupId)
        {
            return _productGroupRepository.GetProductGroups(groupId).Select(g => new SelectListItem()
            {
                Text = g.GroupTitle,
                Value = g.GroupdId.ToString()
            }).ToList();
        }


        public OperationResult CreateGroup(CreateGroupCommand command)
        {
            var result = new OperationResult();
            if (_productGroupRepository.IsExistGroup(command.Title))
                return result.Failed(ApplicationMessages.DuplicatedGroup);
            var imageName = DefaultImages.DefaultProductGroupImage;
            if (command.GroupImage != null)
            {
                imageName = CodeGenerator.GenerateUniqName() + Path.GetExtension(command.GroupImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Products",
                    "ProductGroupImages",
                    imageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                    command.GroupImage.CopyTo(stream);
            }

            var group = new ProductGroup(command.Title, command.ParentId, imageName);
            _productGroupRepository.Add(group);
            return result.Succeeded();
        }

        public Tuple<List<ProductGroupViewModel> , int, int, int> GetProductGroupsForShow(int pageId = 1, string title = "", int take = 10)
        {
            var skip = (pageId - 1) * take;
            var groups = _productGroupRepository.GetProductGroupsForShow(title).Skip(skip).Take(take)
                .Select(g=>new ProductGroupViewModel()
                {
                    GroupId = g.GroupdId,
                    ParentId = g.ParentId,
                    ImageName = g.ImageName,
                    GroupTitle = g.GroupTitle
                }).ToList();
            var pageCount = groups.Count() / take;
            if (groups.Count() % take != 0)
                pageCount++;
            return Tuple.Create(groups, pageId, pageCount, take);
        }

        public Tuple<List<ProductGroupViewModel>, int, int, int> GetProductGroupdForShow(int pageId = 1, string title = "", int take = 10)
        {
            throw new NotImplementedException();
        }
    }
}
