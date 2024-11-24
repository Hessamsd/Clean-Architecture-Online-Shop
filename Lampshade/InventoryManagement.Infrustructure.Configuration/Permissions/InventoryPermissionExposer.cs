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
                       new PermissionsDto(InventoryPermissions.ListInventory,"ListInventory"),
                       new PermissionsDto(InventoryPermissions.SearchInventory,"SearchInventory"),
                       new PermissionsDto(InventoryPermissions.CreateInventory,"CreateInventory"),
                       new PermissionsDto(InventoryPermissions.EditInventory,"EditInventory"),
                       new PermissionsDto(InventoryPermissions.Increase,"Increase"),
                       new PermissionsDto(InventoryPermissions.Reduce,"Reduce"),
                       new PermissionsDto(InventoryPermissions.OperationLog,"OperatoinLog")

                    }
                }

            };
        }
    }
}
