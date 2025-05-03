using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Queries
{
    public class GetByIdProductQuery:IRequest<BaseReponseGeneric<GetProductDto>>
    {
        public int Id { get; set; }
        
    }
}
