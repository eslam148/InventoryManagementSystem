using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common.Enums;

namespace InventoryManagementSystem.Domain.Common
{
    public class BaseReponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string InternalMessage { get; set; }
    }

   
}
