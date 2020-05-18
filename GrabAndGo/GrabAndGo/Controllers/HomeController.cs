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
using System.IO;
using Microsoft.Extensions.Configuration;

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

        [AllowAnonymous]
        public IActionResult MainPage()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Map()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string GoogleMaps = configuration.GetValue<string>("Google:Maps");
            ViewBag.GoogleMaps = GoogleMaps;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddressLookup()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(repository.Products);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult HomePage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SignUp()
        {
            var newUser = new User();
            return View(newUser);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View();
        }

        //public async Task<IActionResult> List2(int listID, string searchString)
        [Authorize(Roles = "Admin")]
        public IActionResult List2(int listID)
        {
            ViewBag.ListID = listID;
            return View(listRepo.ShoppingListLines.Where(p => p.ListID.Equals(listID)));
        }
    }
}
