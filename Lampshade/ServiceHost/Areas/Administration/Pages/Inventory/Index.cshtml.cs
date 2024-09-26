using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {

        [TempData]
        string Message { get; set; }
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> Inventory;
        public SelectList Products;


        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Inventory = _inventoryApplication.Serach(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var inventory = _inventoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts();
            return Partial("Edit", inventory);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetIncrease(int id)
        {

            var command = new IncreaseInventory()
            {
                InventoryId = id
            };

            return Partial("Increase", command);

        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);

        }


        public IActionResult OnGetReduce(int id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };

            return Partial("Reduce", command);
        }


        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(int id)
        {
            var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog",log);
        }
    }

}
