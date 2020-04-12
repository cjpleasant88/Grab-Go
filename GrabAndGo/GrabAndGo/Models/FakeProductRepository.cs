using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {ProductID = 1, ProductName = "Milk", Price = 3.49M, SectionID = 21},
            new Product {ProductID = 2, ProductName = "Bread", Price = 1.89M, SectionID = 32},
            new Product {ProductID = 3, ProductName = "Eggs", Price = 2.49M, SectionID = 45}

        }.AsQueryable<Product>();

        public IQueryable<Store> Stores => new List<Store>
        {
            new Store {StoreID = 1, City="Ocenaside", State ="CA", StoreName="Target", Street="123 BeachTime", ZipCode=12345},
            new Store {StoreID = 2, City="Vista", State ="CA", StoreName="Ralphs", Street="456 ImHungry", ZipCode=98765}


        }.AsQueryable<Store>();

        public IQueryable<User> Users => new List<User>
        {
            new User {UserID = 1, FirstName = "Test User", LastName = "Test Last", Email = "test123@456.com", Password = "superSecret", ListID = 123, StorePref = 1},
            new User {UserID = 2, FirstName = "John", LastName = "Smith", Email = "john@grabandgo.com", Password = "johnnyrocks", ListID = 3, StorePref = 2}
        }.AsQueryable<User>();

        public Product Add(Product product)
        {
            return product;
        }

        public Product GetProduct(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
