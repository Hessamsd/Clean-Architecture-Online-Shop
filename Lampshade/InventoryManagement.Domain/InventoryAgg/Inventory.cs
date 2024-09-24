using _0_Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public int ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }


        public Inventory(int productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        private int CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(int count, int operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount,
                description, 0, Id);
            Operations.Add(operation);

            //if(currentCount > 0)
            //    InStock = true;
            //else
            //    InStock = false;

            InStock = currentCount > 0;
        }

        public void Reduce(int count, int operatorId, string description, int orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }


    }

    public class InventoryOperation
    {
        public int Id { get; private set; }
        public bool Operation { get; private set; }
        public int Count { get; private set; }
        public int OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public int CurrentCount { get; private set; }
        public string Description { get; private set; }
        public int OrderId { get; private set; }
        public int InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        public InventoryOperation(bool operartion, int count, int operatorId, int currentCount,
            string description, int orderId, int inventoryId)
        {
            Operation = operartion;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
        }
    }
}



