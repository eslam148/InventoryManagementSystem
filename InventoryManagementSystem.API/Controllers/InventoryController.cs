using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Application.Features.Inventory.Orchestrators;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddQuantityToInventory")]
        public async Task<IActionResult> AddQuantityToInventory(AddQuntityFromInventoryDTO addQuntityFromInventoryDTO)
        {
            AddQuantityToInventoryOrchestrator command = new AddQuantityToInventoryOrchestrator { InventoryId = addQuntityFromInventoryDTO.InventoryId,  ProductId = addQuntityFromInventoryDTO.productId, Quantity = addQuntityFromInventoryDTO.quantity };
            BaseReponseGeneric<bool> result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("RemoveQuantityToInventory")]
        public async Task<IActionResult> RemoveQuantityToInventory(RemoveQuntityFromInventoryDTO removeQuntityFromInventoryDTO)
        {
            RemoveQuantityFromInventoryOrchestrator command = new RemoveQuantityFromInventoryOrchestrator { InventoryId = removeQuntityFromInventoryDTO.InventoryId, ProductId = removeQuntityFromInventoryDTO.productId, Quantity = removeQuntityFromInventoryDTO.quantity };
            BaseReponseGeneric<bool> result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("TransfairProductToInventory")]
        public async Task<IActionResult> TransfairProductToInventory(TransferProductToInventoryDTO transferProductToInventoryDTO)
        {
            TransfairProductToInventoryOrchestrator command = new TransfairProductToInventoryOrchestrator { FromInventoryId = transferProductToInventoryDTO.FromInventoryId,ToInventoryId = transferProductToInventoryDTO.ToInventoryId, ProductId = transferProductToInventoryDTO.ProductId, Quantity = transferProductToInventoryDTO.Quantity};
            BaseReponseGeneric<bool> result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
