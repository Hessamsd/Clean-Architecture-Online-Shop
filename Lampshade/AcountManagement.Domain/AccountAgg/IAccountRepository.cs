using _0_Framework.Domain;
using AccountManagement.Application.Contract.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<int,Account>
    {
        Account GetBy(string username);
        EditAccount GetDetails(int id);

        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
