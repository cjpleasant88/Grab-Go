using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrabAndGo.Data;

namespace GrabAndGo.Models
{
    public class EFShoppingListLineRepository : IShoppingListLineRepository
    {
        private readonly GrabAndGoContext context;

        public EFShoppingListLineRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<ShoppingListLine> ShoppingListLines => context.ShoppingListLine;
    }
}
