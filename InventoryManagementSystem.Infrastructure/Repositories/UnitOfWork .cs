using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplictionContext _context;
     
        private IRepository<Product> _productRepository;    
        private IRepository<Inventory> _inventoryRepository;
        private IRepository<InventoryTransaction> _inventoryTransactionRepository;
        private IRepository<InventoryProduct> _inventoryProductRepository;
        private IRepository<Notification> _notificationRepository;

        public IRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository ??= new Repository<Product>(_context);
            }
        }
        public IRepository<Inventory> InventoryRepository
        {
            get
            {
                return _inventoryRepository ??= new Repository<Inventory>(_context);
            }
        }
        public IRepository<InventoryTransaction> InventoryTransactionRepository
        {
            get
            {
                return _inventoryTransactionRepository ??= new Repository<InventoryTransaction>(_context);
            }
        }
        public IRepository<InventoryProduct> InventoryProductRepository
        {
            get
            {
                return _inventoryProductRepository ??= new Repository<InventoryProduct>(_context);
            }
        }
        public IRepository<Notification> NotificationRepository
        {
            get
            {
                return _notificationRepository ??= new Repository<Notification>(_context);
            }
        }
        public UnitOfWork(ApplictionContext context)
        {
            _context = context;
        }

        

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
