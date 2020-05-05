using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class FakeShoppingListLineRepository  : IShoppingListLineRepository
    {
        public IQueryable<ShoppingListLine> ShoppingListLines => new List<ShoppingListLine>
        {
            new ShoppingListLine { ShoppingListLineID = 1, ListID = 1, ProductID = 1, Quantity = 2},
            new ShoppingListLine { ShoppingListLineID = 2, ListID = 2, ProductID = 2, Quantity = 3}
        }.AsQueryable<ShoppingListLine>();
    }
}
