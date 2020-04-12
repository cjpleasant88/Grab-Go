using GrabAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class EFUserRepository : IUserRepository
    {
        private readonly GrabAndGoContext context;

        public EFUserRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.User;
    }
}
