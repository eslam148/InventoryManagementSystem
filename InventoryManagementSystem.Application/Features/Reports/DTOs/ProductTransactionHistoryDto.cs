using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Enums;

namespace InventoryManagementSystem.Application.Features.Reports.DTOs
{
    public class ProductTransactionHistoryDto
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; } 
        public string UserName { get; set; }

        public string FromInventoryName { get; set; }
        public string ToInventoryName { get; set; }


    }
}
