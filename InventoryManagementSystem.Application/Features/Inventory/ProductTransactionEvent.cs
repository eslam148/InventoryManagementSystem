using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Enums;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Inventory
{
    public class ProductTransactionEvent: INotification
    {

        public int ProductId { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public int? FromInventoryId { get; set; }
        public int? ToInventoryId { get; set; }
    }
  
}
