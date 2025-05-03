using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Application.Features.Inventory.Orchestrators;
using InventoryManagementSystem.Application.Features.Inventory.Query;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Application.Features.Products.Handlers;
using InventoryManagementSystem.Application.Features.Products.Queries;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Enums;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Inventory.Handler.OrchestratorsHandler
{
    public class AddQuantityToInventoryOrchestratorHandler: IRequestHandler<AddQuantityToInventoryOrchestrator, BaseReponseGeneric<bool>>
    {
        private readonly IMediator _mediator;
        public AddQuantityToInventoryOrchestratorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(AddQuantityToInventoryOrchestrator request, CancellationToken cancellationToken)
        {
            BaseReponseGeneric<GetInventoryProductsDTO> GetInventoryProduct = await _mediator.Send(new GetInventoryProductsByIdsQuery { InventoryId = request.InventoryId, ProductId = request.ProductId });
            if(GetInventoryProduct.IsSuccess == false)
            {
                return ResponseFactory<bool>.NotFound("Product not found in inventory");
            }

            BaseReponseGeneric<bool> update =await _mediator.Send(new UpdateProductInventoryCommand
            {
                ProductId = request.ProductId,
                InventoryId = request.InventoryId,
                Quantity = GetInventoryProduct.Data.Quantity + request.Quantity
            });

            if (update.IsSuccess == false)
            {
                return update;
            }
            BaseReponseGeneric<GetProductDto> product = await _mediator.Send(new GetByIdProductQuery
            {
                Id = request.ProductId
            });

            BaseReponseGeneric<bool> updateProduct = await _mediator.Send(new UpdateProductCommand
            {
                LowStockThreshold = product.Data.LowStockThreshold,
                Id = request.ProductId,
                Description = product.Data.Description,
                CategoryId = product.Data.CategoryId,
                Name = product.Data.Name,
                Price = product.Data.Price,
                Quantity = product.Data.Quantity + request.Quantity
            });
            await _mediator.Publish(new ProductTransactionEvent
            {
                ProductId = request.ProductId,
                TransactionType = TransactionType.Add,
                Quantity = request.Quantity,
                FromInventoryId = null,
                ToInventoryId = request.InventoryId
            });
            return updateProduct;
        }
    }
   
}
