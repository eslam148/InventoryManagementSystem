using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Context
{
    public class ApplictionContext: IdentityDbContext<ApplictionUser>
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
 
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplictionContext()
        {
            
        }
        public ApplictionContext(DbContextOptions options):base(options) { }

    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasKey(p=>p.Id);
            builder.Entity<Product>()
                .HasMany(p=>p.Transactions)
                .WithOne(t=>t.Product)
                .HasForeignKey(t=>t.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Product>()
                .HasMany(p => p.InventoryProducts)
                .WithOne(t => t.product)
                .HasForeignKey(t => t.productId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(Category => Category.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<InventoryTransaction>()
                .HasKey(t => t.Id);

            builder.Entity<InventoryTransaction>()
                .HasOne(t => t.Product)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<InventoryTransaction>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

             builder.Entity<InventoryTransaction>()
                    .HasOne(t => t.ToInventory)
                    .WithMany(i => i.ToTransactions)
                    .HasForeignKey(t => t.ToInventoryId)
                    .OnDelete(DeleteBehavior.NoAction);

              builder.Entity<InventoryTransaction>()
                    .HasOne(t => t.FormInventory)
                    .WithMany(i => i.FromTransactions)
                    .HasForeignKey(t => t.FromInventoryId)
                    .OnDelete(DeleteBehavior.NoAction);
            ////////////////////////////////////////////
            builder.Entity<InventoryProduct>()
                .HasKey(x => new { x.productId, x.InventoryId });
                 builder.Entity<InventoryProduct>()
                .Ignore(x => x.Id);
            builder.Entity<InventoryProduct>()
                    .HasOne(t => t.product)
                    .WithMany(i => i.InventoryProducts)
                    .HasForeignKey(t => t.productId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<InventoryProduct>()
                   .HasOne(t => t.inventory)
                   .WithMany(i => i.InventoryProducts)
                   .HasForeignKey(t => t.InventoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Notification>()
                .HasKey(n => n.Id);
            builder.Entity<Notification>()
                .HasOne(n => n.product)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.ProductId)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=InventoryManagementSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate = True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
