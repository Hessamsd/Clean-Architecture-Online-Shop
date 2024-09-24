using ShopManagement.Application.Contracts.Product;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class DefaineColleagueDiscount
    {
        public int ProductId { get;  set; }
        public int DiscountRate { get;  set; }
        List<ProductViewModel> Products { get; set; }
    }
}
