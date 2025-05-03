using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Features.Account.DTOs
{
    public class ResponseLogInDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
    public class LogInDTO
    {

        [Required]
        [EmailAddress]
        public  string Email { get; set; }
        [Required]

        public string Password { get; set; }
     

    }
}
