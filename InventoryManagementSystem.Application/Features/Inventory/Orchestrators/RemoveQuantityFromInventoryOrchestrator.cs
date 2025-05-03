using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Inventory.Orchestrators
{
    public class RemoveQuantityFromInventoryOrchestrator : IRequest<BaseReponseGeneric<bool>>
    {
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
    }
}
