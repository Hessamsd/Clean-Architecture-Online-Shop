namespace _0_Framework.Infrastructure
{
    public class PermissionsDto
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PermissionsDto(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
