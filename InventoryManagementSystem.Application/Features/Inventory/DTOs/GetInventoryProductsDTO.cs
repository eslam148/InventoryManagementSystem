using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Features.Inventory.DTOs
{
    public class GetInventoryProductsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string InventoryId { get; set; }
        public int LowStockThreshold { get; set; }
        public int Quantity { get; set; }

    }
}
