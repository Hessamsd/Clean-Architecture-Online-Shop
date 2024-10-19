using _0_Framework.Domain;
using AccountManagement.Application.Contract.Role;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<int,Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(int id);
    }
}
