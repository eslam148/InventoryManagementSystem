using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Application.Features.Account.DTOs;
using InventoryManagementSystem.Domain.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Features.Account.Commands
{
    public class LogInCommand:IRequest<BaseReponseGeneric<ResponseLogInDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
}
