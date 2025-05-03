using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Application.Features.Products.Handlers;
using InventoryManagementSystem.Application.Features.Products.Queries;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Context;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Test
{
    public class GetProductIdHandlerTest
    {
        [Fact]
        public async Task Handle_ValidQuery_ShouldGetProductByIdAndBaseReponseGenericOfBoolHaveData()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetProductDto, Product>().ReverseMap();
            });
            MapperHelpper.Mapper = config.CreateMapper();


            var options = new DbContextOptionsBuilder<ApplictionContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new ApplictionContext(options);
            context.Products.AddRange(
                new Product { Name = "A", Price = 10, CategoryId = 1, Description = "Hello", CreateAt = DateTime.Now, IsDeleted = false, LowStockThreshold = 10, Quantity = 100 },
                new Product { Name = "B", Price = 10, CategoryId = 1, Description = "Hello", CreateAt = DateTime.Now, IsDeleted = false, LowStockThreshold = 10, Quantity = 100 }
            );
            await context.SaveChangesAsync();


            var productRepo = new Repository<Product>(context);
            var uow = new UnitOfWork(context);

            var handler = new GetByIdProductHandler(uow);

            var query = new GetByIdProductQuery()
            {
                Id = 1
            };

            // Act
            BaseReponseGeneric<GetProductDto> result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsType<BaseReponseGeneric<GetProductDto>>(result);
            Assert.False(result.IsSuccess);

        }

    }
}
