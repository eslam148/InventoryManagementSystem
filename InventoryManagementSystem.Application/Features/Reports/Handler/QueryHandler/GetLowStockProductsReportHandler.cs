using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Reports.DTOs;
using InventoryManagementSystem.Application.Features.Reports.Queries;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Application.Features.Reports.Handler.QueryHandler
{
    public class GetLowStockProductsReportHandler:IRequestHandler<GetLowStockProductsReportQuery, BaseReponseGeneric<List<LowStockProductReportDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetLowStockProductsReportHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseReponseGeneric<List<LowStockProductReportDto>>> Handle(GetLowStockProductsReportQuery request, CancellationToken cancellationToken)
        {
           List<LowStockProductReportDto> lowStockProductReportDtos = await _unitOfWork.ProductRepository.GetAll(x=>x.Quantity < x.LowStockThreshold).Select(p=> new LowStockProductReportDto
             {
                 ProductId = p.Id,
                 ProductName = p.Name,
                 Quantity = p.Quantity,
                 LowStockThreshold = p.LowStockThreshold,
             }).ToListAsync();
            return ResponseFactory<List<LowStockProductReportDto>>.Success(lowStockProductReportDtos,"Low stock products retrieved successfully");
           
        }
    }
     
}
