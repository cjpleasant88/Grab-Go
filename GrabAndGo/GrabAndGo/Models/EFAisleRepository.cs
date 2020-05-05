using GrabAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class EFAisleRepository : IAisleRepository
    {
        private readonly GrabAndGoContext context;

        public EFAisleRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Aisle> Aisles => context.Aisle;
    }
}
