using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Commands
{
    public class DeleteProductCommand: IRequest<BaseReponseGeneric<bool>>
    {
        public int Id { get; set; }
    }
}
