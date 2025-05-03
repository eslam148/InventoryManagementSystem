using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Application.Features.Inventory.Handler.CommandHandler;
using InventoryManagementSystem.Application.Features.Inventory.Query;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Application.Features.Inventory.Handler
{
    public class GetInventoryProductsByIdsHandler : IRequestHandler<GetInventoryProductsByIdsQuery, BaseReponseGeneric<GetInventoryProductsDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        ILogger<GetInventoryProductsByIdsHandler> _logger;
        public GetInventoryProductsByIdsHandler(IUnitOfWork unitOfWork, ILogger<GetInventoryProductsByIdsHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseReponseGeneric<GetInventoryProductsDTO>> Handle(GetInventoryProductsByIdsQuery request, CancellationToken cancellationToken)
        {
            InventoryProduct inventoryProduct = await _unitOfWork.InventoryProductRepository.FirstOrDefuiltAsync(ip=> ip.productId == request.ProductId && ip.InventoryId == request.InventoryId,true);
            if (inventoryProduct == null) {
                ResponseFactory<GetInventoryProductsDTO>.NotFound("Product not found in inventory");
            }
            GetInventoryProductsDTO getInventoryProductsDTO = inventoryProduct.Map<GetInventoryProductsDTO>();
            return  ResponseFactory<GetInventoryProductsDTO>.Success(getInventoryProductsDTO, "Get Inventory Products By Ids Successfully");
        }
    }
    
}
