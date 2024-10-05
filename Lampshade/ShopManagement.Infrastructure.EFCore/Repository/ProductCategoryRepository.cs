using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{

    public class ProductCategoryRepository : RepositoryBase<int, ProductCategory>, IProductCategoryRepository
    {

        private readonly ShopContext _Context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }



        public EditProductCategory GetDetails(int id)
        {
            return _Context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _Context.ProductCategories.Select(x => new ProductCategoryViewModel
            {

                Id = x.Id,
                Name = x.Name

            }).ToList();
        }

        public string GetSlugById(int id)
        {
            return _Context.ProductCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _Context.ProductCategories.Select(x => new ProductCategoryViewModel
            {

                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
