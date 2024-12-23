﻿using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {

        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;


        public AccountApplication(IFileUploader fileUploader, IAccountRepository accountRepository, IPasswordHasher passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _fileUploader = fileUploader;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(command.Id);

            if (account == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessage.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.UserName == command.UserName || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.FullName, command.UserName, password
                , command.Mobile, command.RoleId, picturePath);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_accountRepository.Exists(x => x.UserName == command.UserName && x.Mobile == command.Mobile && x.Id != command.Id))
                operation.Failed(ApplicationMessage.DuplicatedRecord);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.FullName, command.UserName, command.Mobile, command.RoleId, picturePath);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAccount GetDetails(int id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.UserName);
            if (account == null)
                return operation.Failed(ApplicationMessage.WrongUserPass);

            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessage.WrongUserPass);

            var permissions = _roleRepository.Get(account.RoleId).Permissions.Select(x => x.Code).ToList();


            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.FullName, account.UserName,permissions);
            _authHelper.Signin(authViewModel);
            return operation.Succedded();

        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
