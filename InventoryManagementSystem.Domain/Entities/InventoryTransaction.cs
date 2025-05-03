using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Enums;

namespace InventoryManagementSystem.Domain.Entities
{
    public class InventoryTransaction: BaseEntity
    {

     
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [ForeignKey(nameof(ToInventory))]
        public int? ToInventoryId { get; set; }

        [ForeignKey(nameof(FormInventory))]
        public int? FromInventoryId { get; set; }


        public Inventory? FormInventory { get; set; }


        public Inventory? ToInventory { get; set; }
        public ApplictionUser User { get; set; }

        public Product Product { get; set; }

    }
}
