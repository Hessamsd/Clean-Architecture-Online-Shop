using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;


namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account() { }

        public Account(string fullName, string userName, string password,
            string mobile, int roleId, string profilePhotho)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            ProfilePhoto = profilePhotho;
        }

        public void Edit(string fullName, string userName,
            string mobile, int roleId, string profilePhotho)
        {
            FullName = fullName;
            UserName = userName;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhotho))
                ProfilePhoto = profilePhotho;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

    }
}
