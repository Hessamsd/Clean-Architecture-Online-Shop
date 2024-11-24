using _0_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {

            return new Dictionary<string, List<PermissionsDto>>
            {

                {
                    "Product",new List<PermissionsDto>
                    {
                     new PermissionsDto(ShopPermissions.ListProducts,"ListProducts"),
                     new PermissionsDto(ShopPermissions.SearchProducts,"SearchProducts"),
                     new PermissionsDto(ShopPermissions.CreateProducts,"CreateProduct"),
                     new PermissionsDto(ShopPermissions.EditProducts,"EditProduct")

                    }

                },
                {
                    "ProductCategory",new List<PermissionsDto>
                    {
                        new PermissionsDto(ShopPermissions.SearchProductCategories,"SearchProductCategory"),
                        new PermissionsDto(ShopPermissions.ListProductCategories,"ListProductCategory"),
                        new PermissionsDto(ShopPermissions.CreateProductsCategory,"CreateProductCategory"),
                        new PermissionsDto(ShopPermissions.EditProductCategory,"EditProductCategory")

                    }
                }

            };
        }
    }
}
