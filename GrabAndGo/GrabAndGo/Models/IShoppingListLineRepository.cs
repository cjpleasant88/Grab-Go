﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public interface IShoppingListLineRepository
    {
        IQueryable<ShoppingListLine> ShoppingListLines { get; }
    }
}
