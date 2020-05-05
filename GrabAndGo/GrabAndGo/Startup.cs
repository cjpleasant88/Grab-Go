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


            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContext<GrabAndGoContext>(options =>
                    options.UseSqlServer(Configuration["Data:GrabAndGoContext:ConnectionString5"]));

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
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=MainPage}/{id?}");
            });

            //SeedData.EnsurePopulated(app);
        }
    }
}
