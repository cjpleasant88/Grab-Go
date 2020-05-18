using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GrabAndGo.Data
{
    public class GrabAndGoContext : IdentityDbContext<ApplicationUser>
    {
        public GrabAndGoContext(DbContextOptions<GrabAndGoContext> options) : base(options)
        {

        }

        public DbSet<Aisle> Aisle { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ShoppingListLine> ShoppingListLine { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Store>().HasData(
        //         new Store { StoreID = 1, City = "Ocenaside", State = "CA", StoreName = "Target", Street = "123 BeachTime", ZipCode = 12345 },
        //    new Store { StoreID = 2, City = "Vista", State = "CA", StoreName = "Ralphs", Street = "456 ImHungry", ZipCode = 98765 }
        //        );

        //    modelBuilder.Entity<Aisle>().HasData(
        //         new Aisle { AisleID = 1, StoreID = 1, AisleNumber = 1, CategoryID = 1 },
        //    new Aisle { AisleID = 2, StoreID = 1, AisleNumber = 2, CategoryID = 3 },
        //    new Aisle { AisleID = 3, StoreID = 2, AisleNumber = 1, CategoryID = 2 }
        //        );

        //    modelBuilder.Entity<Category>().HasData(
        //         new Category { CategoryID = 1, CategoryName = "Dairy" },
        //    new Category { CategoryID = 2, CategoryName = "Bakery" }
        //        );

        //    modelBuilder.Entity<Product>().HasData(
        //        new Product { ProductID = 1, ProductName = "Milk", CategoryID = 1 },
        //    new Product { ProductID = 2, ProductName = "Bread", CategoryID = 2 },
        //    new Product { ProductID = 3, ProductName = "Eggs", CategoryID = 3 }
        //        );

        //    //modelBuilder.Entity<ApplicationUser>().HasData(
        //    //    new ApplicationUser { Id = 1, FirstName = "Test User", LastName = "Test Last", Email = "test123@456.com", PasswordHash, ListID = 123, ListName = "Test List", StorePref = 1 },
        //    //new ApplicationUser { Id = 2, FirstName = "John", LastName = "Smith", Email = "john@grabandgo.com", Password = "johnnyrocks", ListID = 3, ListName = "John's List", StorePref = 2 }
        //    //    );

        //    modelBuilder.Entity<User>().HasData(
        //        new User { UserID = 1, FirstName = "Test User", LastName = "Test Last", Email = "test123@456.com", Password = "superSecret", ListID = 123, ListName = "Test List", StorePref = 1 },
        //    new User { UserID = 2, FirstName = "John", LastName = "Smith", Email = "john@grabandgo.com", Password = "johnnyrocks", ListID = 3, ListName = "John's List", StorePref = 2 }
        //        );

        //    modelBuilder.Entity<ShoppingListLine>().HasData(
        //         new ShoppingListLine { ShoppingListLineID = 1, ListID = "1", ProductID = 1, ProductName = "Milk", Quantity = 2 },
        //    new ShoppingListLine { ShoppingListLineID = 2, ListID = "2", ProductID = 2, ProductName = "Bread", Quantity = 3 },
        //    new ShoppingListLine { ShoppingListLineID = 3, ListID = "2", ProductID = 3, ProductName = "Eggs", Quantity = 12 }
        //        );
        //}//End Seed Data


    }
}
