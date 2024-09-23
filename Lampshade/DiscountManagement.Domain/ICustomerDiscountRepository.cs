using _0_Framework.Domain;
using DiscountManagement.Application.Contract;

namespace DiscountManagement.Domain
{
    public interface ICustomerDiscountRepository : IRepository<int,CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(int id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
