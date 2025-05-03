using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Account.Commands;
using InventoryManagementSystem.Application.Features.Account.DTOs;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Application.Features.Account.Handler
{
    public class LogInHandler : IRequestHandler<LogInCommand, BaseReponseGeneric<ResponseLogInDTO>>
    {
        private readonly UserManager<ApplictionUser> _userManager;
        public LogInHandler(UserManager<ApplictionUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<BaseReponseGeneric<ResponseLogInDTO>> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            ApplictionUser? user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return  ResponseFactory<ResponseLogInDTO>.NotFound("Account Not Found");
            }
            bool result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                string token = await _userManager.GenerateTokenAsync(user);
                return ResponseFactory<ResponseLogInDTO>.Success(new ResponseLogInDTO
                {
                    Email = user.Email,
                    Name = user.Name,
                    Token = token

                },"Log in Successfuly");
            }
            else
            {
                return ResponseFactory<ResponseLogInDTO>.NotFound("Invalid Email Or Password");
            }
        }
    }

}
