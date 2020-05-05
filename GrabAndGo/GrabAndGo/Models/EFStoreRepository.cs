using GrabAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly GrabAndGoContext context;

        public EFStoreRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Store> Stores => context.Store;
    }
}
