namespace DiscountManagement.Application.Contract
{
    public class DefineCustomerDiscount
    {
        public int ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
    }

}
