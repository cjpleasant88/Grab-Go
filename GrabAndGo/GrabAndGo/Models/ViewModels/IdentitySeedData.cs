using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GrabAndGo.Models.ViewModels
{
    public class IdentitySeedData
    {

        //This receives the UserManager<IdentityUser> as a parameter
        public static async Task EnsurePopulated(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string adminEmail = configuration.GetValue<string>("Admin:adminEmail");
            string adminName = configuration.GetValue<string>("Admin:adminName");
            string adminRole = configuration.GetValue<string>("Admin:adminRole");
            string adminPassword = configuration.GetValue<string>("Admin:adminPassword");

            IdentityRole roleAdmin = await roleManager.FindByNameAsync("Admin");
            if (roleAdmin == null)
            {
                IdentityRole RoleAdmin = new IdentityRole
                {
                    Name = "Admin"
                };
                await roleManager.CreateAsync(RoleAdmin);
            }

            IdentityRole roleUser = await roleManager.FindByNameAsync("Admin");
            if (roleUser == null)
            {
                IdentityRole RoleUser = new IdentityRole
                {
                    Name = "User"
                };
                await roleManager.CreateAsync(RoleUser);
            }

            ApplicationUser user = await userManager.FindByNameAsync(adminEmail);
            if (user == null)
            {
                ApplicationUser User = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = adminName,
                    LastName = adminName,
                    StorePref = 1,
                    ListName = adminName + "'s List"
                };

                var result = await userManager.CreateAsync(User, adminPassword);

                if (result.Succeeded)
                {
                    //Retrieves the new user that now has an Id assigned
                    var admin = await userManager.FindByNameAsync(adminEmail);

                    //assigns their ListId to be the same as their UserId
                    admin.ListID = admin.Id;

                    //Assigns them to the User Role
                    await userManager.AddToRoleAsync(admin, adminRole);

                    await userManager.UpdateAsync(admin);

                    //Assigns them to the User Role
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }
}
