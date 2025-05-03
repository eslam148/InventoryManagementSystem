using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products
{
    public class LowStockThresholdNotificationEvent: INotification
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int LowStockThreshold { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
  
}
