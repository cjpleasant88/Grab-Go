using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrabAndGo.Models;
using GrabAndGo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GrabAndGo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;

            IdentitySeedData.EnsurePopulated(userManager, roleManager).Wait();
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
            string userRole = "User";

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ListName = model.FirstName + "'s List",
                    StorePref = 1

                };
            

                //var role = await roleManager.FindByNameAsync(userRole);




                //Creates the newly created user
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    //Retrieves the new user that now has an Id assigned
                    var newUser = await userManager.FindByNameAsync(model.Email);
                    //assigns their ListId to be the same as their UserId
                    newUser.ListID = newUser.Id;
                    
                    await userManager.UpdateAsync(newUser);

                    //Assigns them to the User Role
                    await userManager.AddToRoleAsync(newUser, userRole);

                    //Sets their session to not be persistent
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
                    return RedirectToAction("YourList", "ShoppingListLines");
                }

                ModelState.AddModelError(string.Empty, "Invlaid Login Attempt");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}