using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Inventory.Query
{
    public class GetInventoryProductsByIdsQuery : IRequest<BaseReponseGeneric<GetInventoryProductsDTO>>
    {
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
    }
}
