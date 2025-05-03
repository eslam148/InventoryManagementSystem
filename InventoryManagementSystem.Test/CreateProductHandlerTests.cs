using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.Handlers;
using InventoryManagementSystem.Application.Helpper;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using InventoryManagementSystem.Infrastructure.Context;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
namespace InventoryManagementSystem.Test
{
    
        public class CreateProductHandlerTests
        {
           

            [Fact]
            public async Task Handle_ValidCommand_ShouldCreateProductAndBaseReponseGenericOfBoolHaveDataTrue()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CrearteProductCommand, Product>();
                });
                MapperHelpper.Mapper = config.CreateMapper();  

                // Arrange  
                var mockRepo = new Mock<IRepository<Product>>();
                mockRepo.Setup(r => r.Add(It.IsAny<Product>()));
                         

                var mockUow = new Mock<IUnitOfWork>();
                mockUow.Setup(u => u.ProductRepository).Returns(mockRepo.Object);
                mockUow.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

                var handler = new CrearteProductHandler(mockUow.Object);

                var command = new CrearteProductCommand
                {
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
                mockRepo.Verify(r => r.Add(It.IsAny<Product>()), Times.Once);
                mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
            }
        
        
        
        }
    }
 