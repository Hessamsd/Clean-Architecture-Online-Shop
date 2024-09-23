using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<int, ProductPicture>, IProductPictureRepository
    {

        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetails(int id)
        {
            return _shopContext.ProductPictures.Select(x => new EditProductPicture
            {
                Id = id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.PictuerId,
                

            }).FirstOrDefault(x => x.Id == id);
        }

       
        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _shopContext.ProductPictures
                .Include(x => x.Product).
                Select(x => new ProductPictureViewModel
                {
                    Id = x.Id,
                    Product = x.Product.Name,
                    Picture = x.Picture,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ProductId = x.ProductId,
                    IsRemoved = x.IsRemoved,

                });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}

