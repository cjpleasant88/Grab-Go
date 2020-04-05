using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int productID);
        IQueryable<Product> Products { get; }
        Product Add(Product product);
    }
}
