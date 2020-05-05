using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        public IQueryable<Category> Categories => new List<Category>
        {
            new Category {CategoryID = 1, CategoryName = "Dairy"},
            new Category {CategoryID = 2, CategoryName = "Bakery" }
        }.AsQueryable<Category>();
    }
}
