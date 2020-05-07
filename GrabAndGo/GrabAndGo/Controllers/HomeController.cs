using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrabAndGo.Models;
using GrabAndGo.Models.ViewModels;
using GrabAndGo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace GrabAndGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IShoppingListLineRepository listRepo;

        public HomeController(IProductRepository repo, IShoppingListLineRepository listItems)
        {
            repository = repo;
            listRepo = listItems;
        }

        public IActionResult Index()
        {
            return View(repository.Products);
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            var newUser = new User();
            return View(newUser);
        }

        public IActionResult List()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult MainPage()
        {
            return View();
        }

        //public async Task<IActionResult> List2(int listID, string searchString)
        public IActionResult List2(int listID)
        {
            //IEnumerable<ShoppingListLine> UserShoppingList = from listItem in listRepo.ShoppingListLines where listItem.ListID == listID select listItem;
            //var list = listRepo.ShoppingListLines.Where(p => p.ListID == listID);

            //Gets all products in product list
            //IQueryable<string> products = from p in repository.Products orderby p.ProductName select p.ProductName;
            //creates a list of all items in the users shoppinglist
            //IQueryable<ShoppingListLine> shoppingList2 = from listItem in listRepo.ShoppingListLines where listItem.ListID == listID select listItem;
            //var products = from p in repository.Products select p;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(p => p.Contains(searchString));
            //}
            //var UserShoppingListModel = new ShoppingList
            //{
            //    Products = await products.ToListAsync(),
            //    UserShoppingList = await shoppingList2.ToListAsync()
            //};
            //return View(UserShoppingListModel);

            //return View(UserShoppingList);
            ViewBag.ListID = listID;

            return View(listRepo.ShoppingListLines.Where(p => p.ListID.Equals(listID)));
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
