using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Reports.DTOs;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Reports.Queries
{
    public class GetLowStockProductsReportQuery: IRequest<BaseReponseGeneric<List<LowStockProductReportDto>>>
    {
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int Quantity { get; set; }
        public int LowStockThreshold { get; set; }
    }
 
}
