using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services
{
    public interface INotificationService
    {
        void ScheduleLowStockCheck();
        Task CheckLowStock();
        void ScheduleTransactionArchival();
        Task ArchiveOldTransactions();
    }
}
