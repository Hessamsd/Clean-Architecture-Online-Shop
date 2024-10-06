using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Runtime.InteropServices;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IFileUploader fileUploader, IProductRepository productRepository, IProductPictureRepository productPictureRepository)
        {
            _fileUploader = fileUploader;
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.PictuerId == command.ProductId))
            //    return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var product = _productRepository.GetProductWithCategory(command.ProductId);

            var path = $"{product.Category.Slug}//{product.Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);

            var productPicture = new ProductPicture(command.ProductId,pictureName,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            // var productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);

            var path = $"{productPicture.Product.Category.Slug}/{productPicture.Product.Slug}";

            var pictureName = _fileUploader.Upload(command.Picture, path);

            productPicture.Edit(command.Id, pictureName, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditProductPicture GetDetails(int id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(int id)
        {

            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
