using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, BaseReponseGeneric<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(request.Id);
            return ResponseFactory<bool>.Success(true, "Product deleted successfully"); 
        }
    }
  
}
