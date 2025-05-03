using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagementSystem.API.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly ApplictionContext _dbContext;
        public TransactionMiddleware(ApplictionContext context)
        {
            _dbContext = context;
           
        }
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            if (httpContext.Request.Method == "GET")
            {
                await next(httpContext);
                return;
            }
            IDbContextTransaction transaction = null;

            try
            {
                transaction = await _dbContext.Database.BeginTransactionAsync();

                await next(httpContext);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
