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
                     new PermissionsDto(10,"ListProducts"),
                     new PermissionsDto(11,"SearchProducts"),
                     new PermissionsDto(12,"CreateProduct"),
                     new PermissionsDto(13,"EditProduct")

                    }

                },
                {
                    "ProductCategory",new List<PermissionsDto>
                    {
                        new PermissionsDto(20,"SearchProductCategory"),
                        new PermissionsDto(21,"ListProductCategory"),
                        new PermissionsDto(22,"CreateProductCategory"),
                        new PermissionsDto(23,"EditProductCategory")

                    }
                }

            };
        }
    }
}
