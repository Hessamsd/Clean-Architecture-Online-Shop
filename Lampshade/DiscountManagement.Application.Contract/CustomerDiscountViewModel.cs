namespace DiscountManagement.Application.Contract
{
    public class CustomerDiscountViewModel
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        
    }
}
