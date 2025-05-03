using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands
{
    public class CrearteProductCommand:IRequest<BaseReponseGeneric<bool>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }
        public int CategoryId { get; set; }
    }
}
