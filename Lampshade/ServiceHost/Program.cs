using _0_Framework.Application;
using BlogManagement.Infrastructure.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrustructure.Configuration;
using ServiceHost.Pages.Shop.ProductCategories;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var connectiostring = builder.Configuration.GetConnectionString("LampShadeDb") ;

            ShopManagementBootstrapper.Configure(builder.Services,connectiostring);
            DiscountManagementBootstrapper.Configure(builder.Services,connectiostring);
            InventoryManagementBootstrapper.Configure(builder.Services, connectiostring);
            BlogManagementBootstrapper.Configure(builder.Services,connectiostring);

            builder.Services.AddTransient<IFileUploader, FileUploader>();


            builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}
