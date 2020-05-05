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
            new Product {ProductID = 1, ProductName = "Milk", CategoryID = 1},
            new Product {ProductID = 2, ProductName = "Bread", CategoryID = 2},
            new Product {ProductID = 3, ProductName = "Eggs", CategoryID = 3}

        }.AsQueryable<Product>();

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
