namespace _0_Framework.Application
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        (bool verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
