using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Application.Features.Products.Queries;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Application.Features.Products.Handlers
{
    public class GetByIdProductHandler:IRequestHandler<GetByIdProductQuery, BaseReponseGeneric<GetProductDto>>
    {
      private readonly   IUnitOfWork _unitOfWork;
        public GetByIdProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<BaseReponseGeneric<GetProductDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _unitOfWork.ProductRepository.GetAll()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product == null)
            {
                return ResponseFactory<GetProductDto>.NotFound("Product not found");
            }
         
            GetProductDto productDto = product.Map<GetProductDto>();
             return ResponseFactory<GetProductDto>.Success(productDto, "Product retrieved successfully");  
        }
    }
    
}
