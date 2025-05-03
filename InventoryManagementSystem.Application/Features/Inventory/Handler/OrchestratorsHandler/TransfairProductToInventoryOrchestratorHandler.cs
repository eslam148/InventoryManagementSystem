using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Application.Features.Inventory.Orchestrators;
using InventoryManagementSystem.Application.Features.Inventory.Query;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Common.Enums;
using InventoryManagementSystem.Domain.Enums;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Inventory.Handler.OrchestratorsHandler
{
    public class TransfairProductToInventoryOrchestratorHandler : IRequestHandler<TransfairProductToInventoryOrchestrator, BaseReponseGeneric<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;   
        private readonly IMediator _mediator;
        public TransfairProductToInventoryOrchestratorHandler(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;   
        }
        public async Task<BaseReponseGeneric<bool>> Handle(TransfairProductToInventoryOrchestrator request, CancellationToken cancellationToken)
        {
            BaseReponseGeneric<GetInventoryProductsDTO> FormInventory = await _mediator.Send(new GetInventoryProductsByIdsQuery { InventoryId = request.FromInventoryId, ProductId = request.ProductId });
            if (FormInventory.IsSuccess == false)
            {
                ResponseFactory<bool>.NotFound("Product not found in inventory");
            }
            if (FormInventory.Data.Quantity < request.Quantity)
            {
                return ResponseFactory<bool>.NotFound("Product quantity is not enough in inventory");
            }

            BaseReponseGeneric<GetInventoryProductsDTO> ToInventory = await _mediator.Send(new GetInventoryProductsByIdsQuery { InventoryId = request.ToInventoryId, ProductId = request.ProductId });
            if (ToInventory.ErrorCode == ErrorCode.NotFound)
            {
                // BaseReponseGeneric<bool> Create = await _mediator.Send(new CreateProductInverntoryCommmad { InventoryId = request.ToInventoryId, ProductId = request.ProductId });
                return ResponseFactory<bool>.NotFound("Product not found in inventory");
            }
            FormInventory.Data.Quantity -= request.Quantity;
            ToInventory.Data.Quantity += request.Quantity;
            BaseReponseGeneric<bool> TransferFrom = await _mediator.Send(new UpdateProductInventoryCommand { InventoryId = request.FromInventoryId, ProductId = request.ProductId, Quantity = FormInventory.Data.Quantity });

            BaseReponseGeneric<bool> TransferTo = await _mediator.Send(new UpdateProductInventoryCommand { InventoryId = request.ToInventoryId, ProductId = request.ProductId, Quantity = ToInventory.Data.Quantity });
            if (TransferFrom.IsSuccess == true && TransferTo.IsSuccess == true)
            {

                await _mediator.Publish(new ProductTransactionEvent
                {
                    ProductId = request.ProductId,
                    TransactionType = TransactionType.transfer,
                    Quantity = request.Quantity,
                    FromInventoryId = request.FromInventoryId,
                    ToInventoryId = request.ToInventoryId
                });
                 return ResponseFactory<bool>.Success(true, "Transfer Product Successfully");

            }
            return ResponseFactory<bool>.Error("Transfer Product Failed");
        }
   
    
    }
}
