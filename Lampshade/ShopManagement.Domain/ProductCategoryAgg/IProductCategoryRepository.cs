using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<int, ProductCategory>
    {

        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
