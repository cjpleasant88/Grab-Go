using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrabAndGo.Models;
using GrabAndGo.Data;
using Microsoft.EntityFrameworkCore;

namespace GrabAndGo.Controllers
{
    public class HomeController : Controller
    {


        private readonly GrabAndGoContext context;

        public HomeController(GrabAndGoContext ctx)
        {
            context = ctx;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.Product.ToListAsync());
        }


        //private IProductsRepository repository;

        //public HomeController(IProductsRepository repo)
        //{
        //    repository = repo;
        //}

        //public IActionResult Index()
        //{
        //    return View(repository.Products);
        //}
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
