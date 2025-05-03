using Bogus;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.FakeData
{
    public class InventoryManagementSystemFakeData
    {
        Faker<Inventory> _faker;
        Faker<Product> _Productfaker;
        Faker<Category> _Categoryfaker;
        Faker<InventoryProduct> _InventoryProductfaker;
        public InventoryManagementSystemFakeData()
        {
            GenerateInventory();
        }
        public IEnumerable<Product> GenerateProduct()
        {
            _Productfaker = new Faker<Product>()
                
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(c => c.Price, f => f.Finance.Amount(1, 1000))
                .RuleFor(c => c.LowStockThreshold, f => f.Random.Int(1, 200));

            return _Productfaker.Generate(10);
        }
        public IEnumerable<Category> GenerateCategory()
        {
            _Categoryfaker = new Faker<Category>()
                
                .RuleFor(c => c.Name, f => f.Commerce.ProductName());
               

            return _Categoryfaker.Generate(5);
        }

        public IEnumerable<Inventory> GenerateInventory()
        {
           
           
            _faker = new Faker<Inventory>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName());
               

            return _faker.Generate(5); // عدد المخازن
        }

        public IEnumerable<InventoryProduct> GenerateInventoryProduct()
        {
            _InventoryProductfaker = new Faker<InventoryProduct>()
            .RuleFor(c => c.Id, f => f.Random.Int(1))
           
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 100))
            .RuleFor(c => c.productId, f => f.Random.Int())
            .RuleFor(c => c.InventoryId, f => f.Random.Int())
            .RuleFor(c => c.product, f => new Product())
            .RuleFor(c => c.inventory, f => new Inventory());
            return _InventoryProductfaker.Generate(50);


        }
    }
}
