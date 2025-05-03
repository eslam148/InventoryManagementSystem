using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Context;
 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryManagementSystem.API.Configurations
{
    public static class IdentityConfiguration
    {
        public static void AddConfigurationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplictionContext>(options =>
             {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(true);
                options.EnableDetailedErrors(true);
             });
            
 
            services.AddIdentity<ApplictionUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplictionContext>()
                    .AddDefaultTokenProviders();
         }
    }
}
