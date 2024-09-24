using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<int, ColleagueDiscount>, IColleagueDiscountRepository
    {

        private readonly DiscountContext _Context;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _Context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(int id)
        {
            return _Context.ColleagueDiscounts.Select(c => new EditColleagueDiscount
            {
                Id = c.Id,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name });
            var query = _Context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {

                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,


            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discount;


        }
    }
}
