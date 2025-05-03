using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Features.Inventory.DTOs
{
    public class AddQuantityOfProductToInventoryDTO
    {
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
    }
}
