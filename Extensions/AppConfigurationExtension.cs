using Microsoft.EntityFrameworkCore;
using RagilHadiworoApp.Models;

namespace RagilHadiworoApp.Extensions
{
    public static class AppConfigurationExtension
    {
        private static string AppConnectionString(IConfiguration config)
        {
            return config["ApplicationConnection:sqlserver"];
        }

        public static void AddApplicationConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(AppConnectionString(configuration)));
            services.AddControllersWithViews();
        }
    }
}
