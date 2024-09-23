namespace DiscountManagement.Application.Contract
{
    public class CustomerDiscountSearchModel
    {
        public int ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
