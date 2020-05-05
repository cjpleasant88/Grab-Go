using GrabAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly GrabAndGoContext context;

        public EFCategoryRepository(GrabAndGoContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Category> Categories => context.Category;
    }
}
