using _0_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(ReduceInventory command);
        OperationResult Reduce(List<ReduceInventory> command);
        EditInventory GetDetails(int id);
        List<InventoryViewModel> Serach(InventorySearchModel command);

        List<InventoryOperationViewModel> GetOperationLog(int inventoryId);
    }
}
