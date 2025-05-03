using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Features.Products.DTOs
{
    public class RemoveQuntityFromInventoryDTO
    {
        [Required]
        public int productId { get; set; }
        [Required]

        public int quantity { get; set; }
        [Required]

        public int InventoryId { get; set; }
    }
}
