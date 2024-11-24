using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AcountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<int, Role>, IRoleRepository
    {

        private readonly AccountContext _context;
        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditRole GetDetails(int id)
        {
            return _context.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
                MappedPermissions = MapPermissions(x.Permissions)

            }).AsNoTracking().FirstOrDefault(x => x.Id == id);

        }

        private static List<PermissionsDto> MapPermissions(IEnumerable<Permission> permissions)
        {
            return permissions.Select(x => new PermissionsDto(x.Code, x.Name)).ToList();
        }

        public List<RoleViewModel> List()
        {
            return _context.Roles.Select(x => new RoleViewModel {

                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();

        }
    }
}
