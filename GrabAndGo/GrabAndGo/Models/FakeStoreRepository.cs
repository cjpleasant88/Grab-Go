using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class FakeStoreRepository : IStoreRepository
    {
        public IQueryable<Store> Stores => new List<Store>
        {
            new Store {StoreID = 1, City="Ocenaside", State ="CA", StoreName="Target", Street="123 BeachTime", ZipCode=12345},
            new Store {StoreID = 2, City="Vista", State ="CA", StoreName="Ralphs", Street="456 ImHungry", ZipCode=98765}
        }.AsQueryable<Store>();
    }
}
