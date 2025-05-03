
using AutoMapper;
using Hangfire;
using InventoryManagementSystem.API.Configurations;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Application.Services;
namespace InventoryManagementSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddConfigurationIdentity(builder.Configuration);
            builder.Services.AddConfigureJwtToken(builder.Configuration);

            builder.Services.AddExtensionConfiguration(builder.Configuration);
            builder.Services.AddSwaggerConfiguration();



 
            var app = builder.Build();

            MapperHelpper.Mapper = app.Services.GetService<IMapper>();
            JWTHelpper.configuration = app.Services.GetService<IConfiguration>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHangfireDashboard("/hangfire");
           
            app.UseHttpsRedirection();

            app.UseAuthentication();  
            app.UseAuthorization();
            using (var scope = app.Services.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                notificationService.ScheduleLowStockCheck();
                notificationService.ScheduleTransactionArchival();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
