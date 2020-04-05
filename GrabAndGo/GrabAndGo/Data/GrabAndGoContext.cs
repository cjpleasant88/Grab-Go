using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Models;

namespace GrabAndGo.Data
{
    public class GrabAndGoContext : DbContext
    {
        public GrabAndGoContext(DbContextOptions<GrabAndGoContext> options) : base(options)
        {

        }

        public DbSet<Aisle> Aisle { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<User> User { get; set; }
    }
}
