﻿using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(int id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();

    }
}
