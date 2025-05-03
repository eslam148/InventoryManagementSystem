using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Features.Inventory.DTOs
{
    public class TransferProductToInventoryDTO
    {
        [Required]
        public int FromInventoryId { get; set; }
        [Required]

        public int ToInventoryId { get; set; }
        [Required]

        public int ProductId { get; set; }
        [Required]

        public int Quantity { get; set; }
    }
}
