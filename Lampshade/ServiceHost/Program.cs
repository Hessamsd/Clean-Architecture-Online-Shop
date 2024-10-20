using _0_Framework.Application;
using AccountManagement.Infrastructure.Configurarion;
using BlogManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrustructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            var connectiostring = builder.Configuration.GetConnectionString("LampShadeDb");

            ShopManagementBootstrapper.Configure(builder.Services, connectiostring);
            DiscountManagementBootstrapper.Configure(builder.Services, connectiostring);
            InventoryManagementBootstrapper.Configure(builder.Services, connectiostring);
            BlogManagementBootstrapper.Configure(builder.Services, connectiostring);
            CommentManagementBootstrapper.Configure(builder.Services, connectiostring);
            AccountManagementBootstrapper.Configure(builder.Services, connectiostring);



            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IAuthHelper, AuthHelper>();
            builder.Services.AddTransient<IFileUploader, FileUploader>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));


            builder.Services.Configure<CookiePolicyOptions>(option =>
            {
                option.CheckConsentNeeded = context => true;
                option.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LogoutPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");

                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}
