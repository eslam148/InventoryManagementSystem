using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Reports.DTOs;
using InventoryManagementSystem.Application.Features.Reports.Queries;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Application.Features.Reports.Handler.QueryHandler
{
    public class GetProductTransactionHistoryHandler: IRequestHandler<GetProductTransactionHistoryQuery, BaseReponseGeneric<List<ProductTransactionHistoryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductTransactionHistoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseReponseGeneric<List<ProductTransactionHistoryDto>>> Handle(GetProductTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            List<ProductTransactionHistoryDto> productTransactionHistoryDtos = await _unitOfWork.InventoryTransactionRepository
                .GetAll(x => x.ProductId == request.ProductId || (x.Date >= request.StartDate && x.Date <= request.EndDate))
                .Include(x => x.Product)
                .Include(x => x.User)
                .Include(x => x.FormInventory)
                .Include(x => x.ToInventory)
                .Select(x => x.Map<ProductTransactionHistoryDto>()).ToListAsync();
                 
            if(productTransactionHistoryDtos.Count() > 0 )
            {
                return ResponseFactory<List<ProductTransactionHistoryDto>>.Success(productTransactionHistoryDtos, "Report Retrived Successfuly");

            }
            return ResponseFactory<List<ProductTransactionHistoryDto>>.NotFound("Report Not Found");

        }
    }
    
}
