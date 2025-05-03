using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Domain.Entities
{
    public class ApplictionUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
