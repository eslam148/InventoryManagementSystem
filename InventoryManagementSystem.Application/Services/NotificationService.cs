 
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using MediatR;
using InventoryManagementSystem.Application.Features.Products;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Services
{
    
    public class NotificationService: INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public NotificationService(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public void ScheduleLowStockCheck()
        {
            RecurringJob.AddOrUpdate("LowStockCheck", () => CheckLowStock(), Cron.Daily);
           

        }

        public async Task CheckLowStock()
        {

            List<Product> lowStockProducts = await _unitOfWork.ProductRepository
                .GetAll(p => p.Quantity <= p.LowStockThreshold)
                .ToListAsync();

            foreach (var product in lowStockProducts)
            {
               await _mediator.Publish(new LowStockThresholdNotificationEvent
                {
                    Message = $"Product {product.Name} is low on stock. Current quantity: {product.Quantity}.",
                    ProductId = product.Id,
                    ProductName = product.Name,
                    LowStockThreshold = product.LowStockThreshold

                });
            }
        }

        public void ScheduleTransactionArchival()
        {
            RecurringJob.AddOrUpdate("ArchiveTransactions", () => ArchiveOldTransactions(), Cron.Yearly);
        }

        public async Task ArchiveOldTransactions()
        {
            var oneYearAgo = DateTime.UtcNow.AddYears(-1);
            var oldTransactions = await _unitOfWork.InventoryTransactionRepository
                .GetAll(t => t.Date < oneYearAgo)
            .ToListAsync();
            await ExportTransactionsToTextFile(oldTransactions);
            foreach(var transaction in oldTransactions)
            {
               await _unitOfWork.InventoryTransactionRepository.DeleteAsync(transaction.Id);
            }
            await _unitOfWork.SaveChangesAsync();

             
        }

        private async Task ExportTransactionsToTextFile(List<InventoryTransaction> oldTransactions)
        {
             
            string filePath = "OldTransactions.txt";   

             using (var writer = new StreamWriter(filePath, append: false))   
                {
                     await writer.WriteLineAsync("Transaction ID | ProductId |  Quantity | Date | UserId");

                  
                    foreach (var transaction in oldTransactions)
                    {
                        string line = $"{transaction.Id} | {transaction.ProductId} | {transaction.Quantity} | {transaction.Date} | { transaction.UserId}";
                        await writer.WriteLineAsync(line);
                    }
                }

            
        }
    }
}
