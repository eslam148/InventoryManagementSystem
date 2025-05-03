using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Products.Handlers
{
    public class CrearteProductHandler:IRequestHandler<CrearteProductCommand, BaseReponseGeneric<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CrearteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(CrearteProductCommand request, CancellationToken cancellationToken)
        {
       
               _unitOfWork.ProductRepository.Add(request.Map<Product>());
           
                await _unitOfWork.SaveChangesAsync();  
                return ResponseFactory<bool>.Success(true, "Create Product successfully");   
        }
    }
  
}
