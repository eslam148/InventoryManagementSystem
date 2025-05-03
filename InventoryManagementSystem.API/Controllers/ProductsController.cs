using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Application.Features.Products.Queries;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.FakeData;
using InventoryManagementSystem.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
      
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
           
        }
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
           var result = await _mediator.Send(new GetByIdProductQuery { Id = id });
           return Ok(result);
        }
        [HttpGet("GetAllProducts")]
     
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
          
             var command = createProductDto.Map<CrearteProductCommand>();
             var result = await _mediator.Send(command);
             return Ok(command);
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var command = updateProductDto.Map<UpdateProductCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = id});
            return Ok(result);
        }
        
    }
}
