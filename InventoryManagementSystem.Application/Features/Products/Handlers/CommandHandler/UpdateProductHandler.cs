using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Handlers
{
    public class UpdateProductHandler: IRequestHandler<UpdateProductCommand, BaseReponseGeneric<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
                Product UpdatedProduct = request.Map<Product>();
                _unitOfWork.ProductRepository.Update(UpdatedProduct);
                await _unitOfWork.SaveChangesAsync();
                return ResponseFactory<bool>.Success(true, "Product updated successfully");  
        }
    }
    
}
