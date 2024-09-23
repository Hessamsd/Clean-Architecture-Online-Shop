using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract;
using DiscountManagement.Domain;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<int, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(int id)
        {
            return _discountContext.customerDiscounts.Select(x => new EditCustomerDiscount
            {

                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                Reason = x.Reason,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name });
            var query = _discountContext.customerDiscounts.Select(x => new CustomerDiscountViewModel
            {

                Id = x.Id,
                ProductId = x.ProductId,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                Reason = x.Reason,
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                var StartDate = DateTime.Now;
                query = query.Where(x => x.StartDateGr > StartDate);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                var EndDate = DateTime.Now;
                query = query.Where(x => x.EndDateGr < EndDate);
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();


            discounts.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discounts;
        }
    }
}
