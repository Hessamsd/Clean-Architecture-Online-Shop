﻿using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AcountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<int, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(int id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {

                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePhotho = x.ProfilePhoto,
                Role = "مدیر سیستم",
                RoleId = 2,
                UserName = x.UserName,

            });


            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                query = query.Where(x => x.FullName.Contains(searchModel.FullName));

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.FullName.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.FullName.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();

        }

    }
}