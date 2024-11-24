using _0_Framework.Infrastructure;

namespace InventoryManagement.Infrustructure.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {

                {
                    "Inventory" , new List<PermissionsDto>
                    {
                       new PermissionsDto(50,"ListInventory"),
                       new PermissionsDto(51,"SearchInventory"),
                       new PermissionsDto(52,"CreateInventory"),
                       new PermissionsDto(53,"EditInventory")

                    }
                }

            };
        }
    }
}
