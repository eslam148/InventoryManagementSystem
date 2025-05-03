using InventoryManagementSystem.Application.Features.Account.Commands;
using InventoryManagementSystem.Application.Features.Account.DTOs;
using InventoryManagementSystem.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var result = await _mediator.Send(new RegisterCommand{ Email = registerDTO.Email,Name = registerDTO.Name,Password = registerDTO.Password });
          
            return Ok(result);  
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO logInDTO)
        {
            var result = await _mediator.Send(new LogInCommand { Email = logInDTO.Email, Password = logInDTO.Password });
            return Ok(result);
        }
        
    }
}
