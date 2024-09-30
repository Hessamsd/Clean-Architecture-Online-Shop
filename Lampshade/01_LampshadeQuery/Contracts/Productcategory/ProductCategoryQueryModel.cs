using _01_LampshadeQuery.Contracts.Product;

namespace _01_LampshadeQuery.Contracts.Productcategory
{
    public class ProductCategoryQueryModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string sluge { get; set; }
        public string  Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public List<ProductQueryModel> Products { get; set; }
    }
}
