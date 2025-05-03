using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Common.Enums;

namespace InventoryManagementSystem.API.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        public GlobalErrorHandlerMiddleware()
        {
            
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await  next(context);
            }
            catch (Exception ex)
            {


                BaseReponseGeneric<bool> ErrorReponse = ResponseFactory<bool>.Error(ex.Message);

                await context.Response.WriteAsJsonAsync(ErrorReponse);
            }
        }
    }
}
