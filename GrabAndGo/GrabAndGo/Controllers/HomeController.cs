using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrabAndGo.Models;
using GrabAndGo.Data;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrabAndGo.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;

        public HomeController(IProductRepository repo)
        {
            repository = repo;
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
            return View();
        }

        public IActionResult List()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
