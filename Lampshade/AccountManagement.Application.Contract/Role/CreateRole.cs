﻿using _0_Framework.Infrastructure;

namespace AccountManagement.Application.Contract.Role
{
    public class CreateRole
    {
        public string Name { get;  set; }
        public List<int> Permissions { get; set; }

    }
}


