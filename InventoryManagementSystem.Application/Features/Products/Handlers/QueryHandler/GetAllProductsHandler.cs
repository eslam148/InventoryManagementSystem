using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Application.Features.Products.Queries;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Application.Features.Products.Handlers
{
    public class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, BaseReponseGeneric<List<GetProductDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllProductsHandler> _logger;
        public GetAllProductsHandler(IUnitOfWork unitOfWork, ILogger<GetAllProductsHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseReponseGeneric<List<GetProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
           List<Product> products = await _unitOfWork.ProductRepository.GetAll().Include(p => p.Category)
                .ToListAsync();
           List<GetProductDto> productDtos = products.Map<List<GetProductDto>>();
 
            return ResponseFactory<List<GetProductDto>>.Success(productDtos, "Products retrieved successfully");



        }
    }
    
}
