using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Data;

namespace GrabAndGo.Models
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //GrabAndGoContext context = app.ApplicationServices.GetRequiredService<GrabAndGoContext>();

            //context.Database.Migrate();

            //if (!context.Store.Any())
            //{
            //    new Store
            //    {
            //        StoreID = 1,
            //        StoreName = "Commissary",
            //        Street = "Bldg 20850, Vandegrift Blvd",
            //        City = "Camp Pendleton",
            //        State = "CA",
            //        ZipCode = 92055
            //    };
            //    new Store
            //    {
            //        StoreID = 2,
            //        StoreName = "Target",
            //        Street = "2255 S El Camino Real",
            //        City = "Oceanside",
            //        State = "CA",
            //        ZipCode = 92054
            //    };
            //    new Store
            //    {
            //        StoreID = 3,
            //        StoreName = "Ralph's",
            //        Street = "101 Old Grove Rd",
            //        City = "Oceanside",
            //        State = "CA",
            //        ZipCode = 92057
            //    };
            //}
            //if (!context.Category.Any())
            //{
            //    new Category
            //    {
            //        CategoryID = 1,
            //        CategoryName = "Bread & Bakery"
            //    };
            //    new Category
            //    {
            //        CategoryID = 2,
            //        CategoryName = "Beer, Wine, & Spirits"
            //    };
            //    new Category
            //    {
            //        CategoryID = 3,
            //        CategoryName = "Beverages: tea, soda, water, coffee, etc."
            //    };
            //    new Category
            //    {
            //        CategoryID = 4,
            //        CategoryName = "Canned Goods"
            //    };
            //    new Category
            //    {
            //        CategoryID = 5,
            //        CategoryName = "Dairy, Eggs & Cheese"
            //    };
            //    new Category
            //    {
            //        CategoryID = 6,
            //        CategoryName = "Frozen Foods"
            //    };
            //    new Category
            //    {
            //        CategoryID = 7,
            //        CategoryName = "Meat & Seafood"
            //    };
            //    new Category
            //    {
            //        CategoryID = 8,
            //        CategoryName = "Paper Products - TP, Paper Towels, cups, plates"
            //    };
            //    new Category
            //    {
            //        CategoryID = 9,
            //        CategoryName = "Produce: Fruits  & Vegetables"
            //    };
            //    new Category
            //    {
            //        CategoryID = 10,
            //        CategoryName = "Grains, Pasta & Sides"
            //    };
            //}
            //if (!context.Aisle.Any())
            //{
            //    new Aisle
            //    {
            //        AisleID = 1,
            //        StoreID = 1,
            //        AisleNumber = 1,
            //        CategoryType = 1
            //    };
            //}
            //if (!context.Section.Any())
            //{
            //    new Section
            //    {
            //        SectionID = 1,
            //        SectionName = "Carbonated Beverage"
            //    };
            //    new Section
            //    {
            //        SectionID = 2,
            //        SectionName = "Milk"
            //    };
            //}
            //if (!context.Shelf.Any())
            //{
            //    new Shelf
            //    {
            //        StoreID = 1,
            //        AisleID = 1,
            //        ShelfID = 1,
            //        SectionID = 1
            //    };
            //}
            //if (!context.Product.Any())
            //{
            //    new Product
            //    {
            //        ProductID = 1,
            //        ProductName = "Milk",
            //        Price = 4.39M,
            //        SectionID = 2
            //    };
            //    new Product
            //    {
            //        ProductID = 2,
            //        ProductName = "Eggs",
            //        Price = 3.12M,
            //        SectionID = 2
            //    };
            //    new Product
            //    {
            //        ProductID = 2,
            //        ProductName = "Orange Juice",
            //        Price = 5.76M,
            //        SectionID = 1
            //    };
            //}

            //if (!context.User.Any())
            //{
            //    new User
            //    {
            //        UserID = 1,
            //        FirstName = "Caleb",
            //        LastName = "Pleasant",
            //        Email = "calebpleasant@gmail.com",
            //        Password = "827ccb0eea8a706c4c34a16891f84e7b",
            //        ListID = 1,
            //        StorePref = 1
            //    };
            //}

            //if (!context.ShoppingList.Any())
            //{
            //    new ShoppingList
            //    {
            //        ListID = 1,
            //        ProductID = 2,
            //        Quantity = 3,
            //        ListName = "Pleasant Home"
            //    };
            //}
        }
    }
}
