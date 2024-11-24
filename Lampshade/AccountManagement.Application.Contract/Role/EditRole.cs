using _0_Framework.Infrastructure;

namespace AccountManagement.Application.Contract.Role
{
    public class EditRole : CreateRole
    {
        public int Id { get; set; }
        public List<PermissionsDto> MappedPermissions { get; set; }
    }
}
