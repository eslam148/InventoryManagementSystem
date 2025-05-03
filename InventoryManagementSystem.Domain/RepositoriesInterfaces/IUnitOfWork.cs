

using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.RepositoriesInterfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }
        public IRepository<Inventory> InventoryRepository{get;}
        public IRepository<InventoryTransaction> InventoryTransactionRepository{ get; }
        public IRepository<InventoryProduct> InventoryProductRepository { get; }
        public IRepository<Notification> NotificationRepository { get; }

        Task SaveChangesAsync();
      
    }
}
