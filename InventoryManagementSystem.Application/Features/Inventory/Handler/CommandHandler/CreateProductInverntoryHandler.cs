using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Application.Features.Inventory.Handler.CommandHandler
{
    public class CreateProductInverntoryHandler:IRequestHandler<CreateProductInverntoryCommmad, BaseReponseGeneric<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        ILogger<CreateProductInverntoryHandler> _logger;
        public CreateProductInverntoryHandler(IUnitOfWork unitOfWork, ILogger<CreateProductInverntoryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(CreateProductInverntoryCommmad request, CancellationToken cancellationToken)
        {

            _unitOfWork.InventoryProductRepository.Add(request.Map<InventoryProduct>());
            await _unitOfWork.SaveChangesAsync();
            return ResponseFactory<bool>.Success(true, "Product Inventory Created Successfully");
        }
    }   
    
}
