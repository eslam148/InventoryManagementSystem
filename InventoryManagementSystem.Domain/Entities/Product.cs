using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Product:BaseEntity
    {
         
        public string Name { get; set; } 
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<InventoryTransaction> Transactions { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<InventoryProduct> InventoryProducts { get; set; }

    }
}
