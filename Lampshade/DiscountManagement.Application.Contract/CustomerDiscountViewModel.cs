namespace DiscountManagement.Application.Contract
{
    public class CustomerDiscountViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }   
        public DateTime StartDateGr { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime EndDateGr { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
    }
}
