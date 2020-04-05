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
                    options.UseSqlServer(Configuration["Data:GrabAndGoContext:ConnectionString4"]));

            //services.AddDbContext<GrabAndGoContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ConnectionString4")));

            services.AddScoped<GrabAndGo.Models.IProductsRepository, GrabAndGo.Models.EFProductsRepository>();
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
