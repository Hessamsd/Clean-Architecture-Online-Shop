namespace _01_LampshadeQuery.Contracts.Productcategory
{
    public interface IProductCategoryQuery
    {

        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }
}
