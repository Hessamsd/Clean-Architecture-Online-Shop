using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _categoryRepository;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetSlugById(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            var product = new Product(command.Name, command.Code, command.ShortDescription, command.Description,
               picturePath, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Slug, command.Keywords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();

            var product = _productRepository.GetProductWithCategory(command.Id);

            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetSlugById(command.CategoryId);
            var path = $"{product.Category.Slug}/{slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            product.Edit(command.Name, command.Code, command.ShortDescription,
                command.Description, picturePath, command.PictureAlt, command.PictureTitle,
                command.CategoryId, command.Keywords, command.MetaDescription, slug);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProduct GetDetails(int id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
