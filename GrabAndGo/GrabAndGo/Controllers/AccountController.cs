using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrabAndGo.Models;
using GrabAndGo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GrabAndGo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("MainPage", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                   UserName = model.Email,
                   Email = model.Email,  
                   FirstName = model.FirstName,
                   LastName = model.LastName,
                   ListName = model.FirstName + "'s List"
                
            };
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    var newUser = await userManager.FindByNameAsync(model.Email);
                    newUser.ListID = newUser.Id;
                    await userManager.UpdateAsync(newUser);

                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("MainPage", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("MainPage", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invlaid Login Attempt");
            }
            return View(model);
        }
    }
}