using GrabAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class EFProductsRepository : IProductsRepository
    {
        private readonly GrabAndGoContext context;

        public EFProductsRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Product;

        public Product Add(Product product)
        {
            context.Add(product);
            return product;
        }

        public Product GetProduct(int productID)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
