using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class FakeAisleRepository : IAisleRepository
    {
        public IQueryable<Aisle> Aisles => new List<Aisle>
        {
            new Aisle {AisleID = 1, StoreID = 1, AisleNumber = 1, CategoryID = 1},
            new Aisle {AisleID = 2, StoreID = 1, AisleNumber = 2, CategoryID = 3},
            new Aisle {AisleID = 3, StoreID = 2, AisleNumber = 1, CategoryID = 2}
        }.AsQueryable<Aisle>();
    }
}
