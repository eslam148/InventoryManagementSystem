using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Features.Products.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public int LowStockThreshold { get; set; }
        [Required]

        public int CategoryId { get; set; }
    }
}
