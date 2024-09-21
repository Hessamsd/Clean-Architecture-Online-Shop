using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<int, Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProduct GetDetails(int id)
        {
            return _shopContext.Products.Select(p => new EditProduct
            {

                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Keywords = p.Keywords,
                CategoryId = p.CategoryId,
                Description = p.Description,
                MetaDescription = p.MetaDescription,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                ShortDescription = p.ShortDescription,
                Slug = p.Slug,
                UnitPrice = p.UnitPrice,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _shopContext.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {

                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Picture = x.Picture,
                UnitPrice = x.UnitPrice,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                IsInStock = x.IsInStock,
                CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code == searchModel.Code);

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
