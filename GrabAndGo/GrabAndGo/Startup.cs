using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Data;
using Microsoft.Extensions.Configuration;
using GrabAndGo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace GrabAndGo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc(option =>
                {
                    option.EnableEndpointRouting = false;

                    //The Below two lines enforce a global Authorization policy and must be logged in to do anything
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    option.Filters.Add(new AuthorizeFilter(policy));
                });

            services.AddDbContext<GrabAndGoContext>(options =>
                    options.UseSqlServer(Configuration["Data:GrabAndGoContext:ConnectionString5"]));

            //Using the Identity Servieds all while changing the password Regular Expression charactersitics to allow less secure passwords.
            //Passowrd only needs to be 3 characters in length and needs 3 different characters
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<GrabAndGoContext>();

            //Below Not Needed as it is done in the services.AddIdentity line above
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequiredUniqueChars = 0;
            //});

            //ANOTHER WAY TO CONNECT
            //services.AddDbContext<GrabAndGoContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ConnectionString4")));

            //THIS TO USE THE Database REPOSITORY
            //services.AddSingleton<IProductRepository, EFProductsRepository>();    //This makes a single instance that is reused throughout application on new requests (Good for a cart)
            //services.AddScoped<IProductRepository, EFProductsRepository>();       //Same instance inscope of same request, new instance upon new request-like a post request (Good for creating a new Product, user, etc)

            services.AddTransient<IProductRepository, EFProductRepository>();      //A new instance is created no matter what request is made
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IStoreRepository, EFStoreRepository>();
            services.AddTransient<IAisleRepository, EFAisleRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<IShoppingListLineRepository, EFShoppingListLineRepository>();
            //----------------------------------------------
            //THIS TO USE THE FAKE REPOSITORY
            //services.AddTransient<IProductRepository, FakeProductRepository>();
            //services.AddTransient<IUserRepository, FakeUserRepository>();
            //services.AddTransient<IStoreRepository, FakeStoreRepository>();
            //services.AddTransient<IAisleRepository, FakeAisleRepository>();
            //services.AddTransient<ICategoryRepository, FakeCategoryRepository>();
            //services.AddTransient<IShoppingListLineRepository, FakeShoppingListLineRepository>();
            //---------------------------------------------------------------

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                //app.UseStatusCodePages();
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");

                //This will return the original status (code ex:"404") instead of the Change URL status code of 302
                app.UseStatusCodePagesWithReExecute("/Error/{0)}");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {

                //routes.MapRoute(
                //    name: null,
                //    template: "{controller}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=MainPage}/{id?}");
            });

            //SeedData.EnsurePopulated(app);
        }
    }
}
