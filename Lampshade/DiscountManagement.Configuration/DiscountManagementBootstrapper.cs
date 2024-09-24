﻿using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstrapper
    {

        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication,CustomerDiscountApplication>();

            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddTransient<IColleagueDiscountRepository,ColleagueDiscountRepository>();


            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
