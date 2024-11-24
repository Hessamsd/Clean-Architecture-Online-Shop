namespace _0_Framework.Application
{
    public interface IAuthHelper
    {

        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel account);

        string CurrenrAccountRole();

        AuthViewModel CurrentAcountInfo();

        List<int> GetPermissions();
    }
}
