using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.Queries;
using InventoryManagementSystem.Application.Helpper.Mapper;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using InventoryManagementSystem.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Features.Inventory.Log;
using InventoryManagementSystem.Application.Features.Inventory.Orchestrators;
using InventoryManagementSystem.Application.Features.Inventory;
using InventoryManagementSystem.Application.Features.Reports.Queries;
using System.Reflection;
using Hangfire;
using InventoryManagementSystem.Application.Services;

namespace InventoryManagementSystem.API.Configurations
{
    public static class ExtensionConfiguration
    {
        public static void AddExtensionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddMediatR(opts =>
               opts.RegisterServicesFromAssembly(typeof(TransfairProductToInventoryOrchestrator).Assembly));
          
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            services.AddAutoMapper(typeof(InventoryProfile).Assembly);
            services.AddAutoMapper(typeof(ReportProfile).Assembly);
            services.AddScoped<INotificationService, NotificationService>();

            services.AddHangfire(config => config.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();



        }


    }
}
