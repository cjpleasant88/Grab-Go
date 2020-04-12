using GrabAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly GrabAndGoContext context;

        public EFProductRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Product;

        public Product Add(Product product)
        {
            context.Add(product);
            //Need this to save to the actual database, and not just the injected context database
            context.SaveChanges();
            return product;
        }

        public Product GetProduct(int productID)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
