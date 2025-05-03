using InventoryManagementSystem.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
       private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLowStockProductsReport")]
        public async Task<IActionResult> GetLowStockProductsReport()
        {
            var result = await _mediator.Send(new GetLowStockProductsReportQuery());
            return Ok(result);
        }
        [HttpGet("GetProductTransactionHistory")]
        public async Task<IActionResult> GetProductTransactionHistory([FromQuery] GetProductTransactionHistoryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
