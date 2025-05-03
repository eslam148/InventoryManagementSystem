using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Application.Features.Inventory.Query;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Enums;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Inventory.Handler
{
    public class UpdateProductInventoryHandler: IRequestHandler<UpdateProductInventoryCommand, BaseReponseGeneric<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public UpdateProductInventoryHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(UpdateProductInventoryCommand request, CancellationToken cancellationToken)
        {
            BaseReponseGeneric<GetInventoryProductsDTO> Response = await _mediator.Send(new GetInventoryProductsByIdsQuery { InventoryId = request.InventoryId, ProductId = request.ProductId });
            if (Response.IsSuccess == false)
            {
                return ResponseFactory<bool>.NotFound("Product not found in inventory");
            }
            InventoryProduct inventoryProduct = Response.Data.Map<InventoryProduct>();
            inventoryProduct.Quantity = request.Quantity;
            _unitOfWork.InventoryProductRepository.Update(inventoryProduct);
            await _unitOfWork.SaveChangesAsync();
          
            return ResponseFactory<bool>.Success(true, "Quantity added successfully");
        }
    }
    
}
