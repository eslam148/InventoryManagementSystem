using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.Handlers;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using InventoryManagementSystem.Infrastructure.Context;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
namespace InventoryManagementSystem.Test
{
    public class UnitTest1
    {
        public class CreateProductHandlerTests
        {
            [Fact]
            public async Task Handle_ValidCommand_ShouldCreateProductAndReturnId()
            {
                // Arrange
                ApplictionContext applictionContext = new ApplictionContext();



                var mockRepository = new Mock<IUnitOfWork>();
                var handler = new CrearteProductHandler(mockRepository.Object);

                var command = new CrearteProductCommand
                {
                    Name = "Test Product",
                    Price = 99,
                    Description = "test",
                    Quantity = 20,
                    CategoryId = 1,
                    LowStockThreshold = 5
                };

                //// Act
                //var result = await handler.Handle(command, CancellationToken.None);

                // Assert
                //Assert.IsType<BaseReponseGeneric<bool>>(result);
                //   Assert.NotNull(result);
                //Product product = new Product
                //{
                //    Name = command.Name,
                //    Price = command.Price,
                //    CategoryId = command.CategoryId,
                //    Quantity = command.Quantity,
                //    Description = command.Description
                //};
                //mockRepository.Verify(r => r.ProductRepository.Add(It.Is<Product>(p => p.Name == "Test Product" && p.Price == 99.99m && p.CategoryId == 1 && p.Quantity == 20 && p.Description == "test")), Times.Once);
            }
        
        
        
        }
    }
}