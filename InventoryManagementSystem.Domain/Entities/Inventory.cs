using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Inventory:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<InventoryProduct> InventoryProducts { get; set; }

        public ICollection<InventoryTransaction> FromTransactions { get; set; }
        public ICollection<InventoryTransaction> ToTransactions { get; set; }

    }
}
