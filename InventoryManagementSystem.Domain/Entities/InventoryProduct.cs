using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class InventoryProduct:BaseEntity
    {
       
        public int Quantity { get; set; }
        
        [ForeignKey(nameof(product))]
        public int productId { get; set; }
        [ForeignKey(nameof(inventory))]
        public int InventoryId { get; set; }
        public Product product { get; set; }
        public Inventory inventory { get; set; }
        
       

    }
}
