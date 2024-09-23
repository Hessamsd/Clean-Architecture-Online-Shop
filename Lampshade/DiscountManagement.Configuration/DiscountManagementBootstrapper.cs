using DiscountManagement.Application;
using DiscountManagement.Application.Contract;
using DiscountManagement.Domain;
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


            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
