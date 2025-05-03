using InventoryManagementSystem.Application.Features.Reports.DTOs;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Reports.Queries
{
    public class GetProductTransactionHistoryQuery : IRequest<BaseReponseGeneric<List<ProductTransactionHistoryDto>>>
    {
        public int ProductId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
    }
}
