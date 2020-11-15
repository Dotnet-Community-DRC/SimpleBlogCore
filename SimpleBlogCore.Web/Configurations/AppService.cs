using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SimpleBlogCore.Data;
using SimpleBlogCore.Data.Models;
using SimpleBlogCore.Service.Interfaces;
using SimpleBlogCore.Web.Helpers;

namespace SimpleBlogCore.Web.Configurations
{
    public static class AppService
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppDbContext>();
            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            serviceCollection.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            serviceCollection.AddTransient<IManageSettings, ManageSettings>();
            serviceCollection.AddTransient<IManageContact, ManageContact>();
            serviceCollection.AddScoped<IDataEncryptionHelper, DataEncryptionHelper>();

            serviceCollection.AddControllersWithViews();
            serviceCollection.AddRazorPages();
        }

        public static void AddCustomerServices(this IServiceCollection serviceCollection)
        {
        }
    }
}