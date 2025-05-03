using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.Handlers;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using Microsoft.Data.SqlClient;
using Moq;

namespace InventoryManagementSystem.Test
{
    public class UpdateProductHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldCreateProductAndBaseReponseGenericOfBoolHaveDataTrue()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateProductCommand, Product>();
            });
            MapperHelpper.Mapper = config.CreateMapper();  

            // Arrange mocks
            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(r => r.Add(It.IsAny<Product>()));


            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(u => u.ProductRepository).Returns(mockRepo.Object);
            mockUow.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

            var handler = new UpdateProductHandler(mockUow.Object);

            var command = new UpdateProductCommand
            {
                Id = 1,
                Name = "Test Product",
                Price = 99,
                Description = "test",
                Quantity = 20,
                CategoryId = 1,
                LowStockThreshold = 5
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsType<BaseReponseGeneric<bool>>(result);
            Assert.True(result.Data);
            
        }

        




    }
}
