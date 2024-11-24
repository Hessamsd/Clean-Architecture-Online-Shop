namespace _0_Framework.Infrastructure
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<PermissionsDto>> Expose();
    }
}
