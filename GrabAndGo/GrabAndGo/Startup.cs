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

            ////THESE TO USE THE DATABASE
            //services.AddDbContext<GrabAndGoContext>(options =>
            //        options.UseSqlServer(Configuration["Data:GrabAndGoContext:ConnectionString4"]));
            //services.AddTransient<IProductRepository, EFProductsRepository>();

            //THIS TO USE THE FAKE REPOSITORY
            services.AddTransient<IProductRepository, FakeProductRepository>();



            //THESE TO TEST OTHER WAYS TO CONNECT
            //services.AddDbContext<GrabAndGoContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ConnectionString4")));

            //services.AddScoped<GrabAndGo.Models.IProductRepository, GrabAndGo.Models.EFProductsRepository>();
            //services.AddScoped<GrabAndGo.Models.IProductRepository, GrabAndGo.Models.FakeProductRepository>();
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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
