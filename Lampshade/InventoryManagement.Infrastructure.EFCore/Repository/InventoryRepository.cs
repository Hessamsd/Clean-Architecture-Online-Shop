using _0_Framework.Application;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<int, Inventory>, IInventoryRepository
    {

        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public Inventory GetBy(int productId)
        {
            return _context.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(int id)
        {
            return _context.Inventory.Select(x => new EditInventory
            {

                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(int InventoryId)
        {
            var inventory = _context.Inventory.FirstOrDefault(x => x.Id == InventoryId);
            return inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                CurrentCount = x.CurrentCount,
                Count = x.Count,
                Description = x.Description,
                Operation = x.Operation,
                Operator = "مدیر سیستم",
                OperatorId = x.OperatorId,
                OperationDate = x.OperationDate.ToFarsi(),
                OrderId = x.OrderId,

            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<InventoryViewModel> Serach(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name });
            var query = _context.Inventory.Select(x => new InventoryViewModel
            {

                Id = x.Id,
                ProductId = x.ProductId,
                CurrentCount = x.CalculateCurrentCount(),
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CreationDate = x.CreationDate.ToFarsi(),

            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(item => item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);
            return inventory;
        }
    }
}
