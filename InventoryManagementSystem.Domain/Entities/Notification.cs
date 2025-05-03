using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Notification:BaseEntity
    {
        public int LowStockThreshold { get; set; }
        public string Message { get; set; }
        [ForeignKey(nameof(product))]
        public int ProductId { get; set; }
        public Product product { get; set; }

    }
}
