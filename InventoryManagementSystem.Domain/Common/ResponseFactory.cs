using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common.Enums;

namespace InventoryManagementSystem.Domain.Common
{
    public static class  ResponseFactory<T>
    {

        public static BaseReponseGeneric<T> Success(T Data,string Message)
        {
            return new BaseReponseGeneric<T>
            {
                Data = Data,
                Message = Message,
                ErrorCode = ErrorCode.Success,
                IsSuccess = true
            };
        }

        public static BaseReponseGeneric<T>  Error( string Errors = null)
        {
            return new BaseReponseGeneric<T>
            {
         
                ErrorCode =  ErrorCode.InternalServerError,
                IsSuccess = false,
                InternalMessage = Errors
            };
        }
        public static BaseReponseGeneric<T> NotFound(string Message)
        {
            return new BaseReponseGeneric<T>
            {
                Message = Message,
                ErrorCode = ErrorCode.NotFound,
                IsSuccess = false
            };
        }

    }
}
