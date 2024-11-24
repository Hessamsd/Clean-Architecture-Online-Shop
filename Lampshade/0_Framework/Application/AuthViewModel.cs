﻿namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(int id, int roleId, string fullName, string userName, List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            FullName = fullName;
            UserName = userName;
            Permissions = permissions;
        }
    }
}
