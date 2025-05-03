using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Account.Commands;
using InventoryManagementSystem.Application.Features.Account.DTOs;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Application.Features.Account.Handler
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, BaseReponseGeneric<bool>>
    {
        private readonly UserManager<ApplictionUser> _userManager;
        public RegisterHandler(UserManager<ApplictionUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<BaseReponseGeneric<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ApplictionUser user = new ApplictionUser
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return ResponseFactory<bool>.Success(true, "Account Created Successfully");
            }
            else
            {
                return ResponseFactory<bool>.NotFound("Account Not Created");
            }
           
        }
    }    
}
