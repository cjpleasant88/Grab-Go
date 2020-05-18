using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore;

namespace GrabAndGo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = BuildWebHostBuilder(args);

            var host = CreateHostBuilder(args).Build();

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //public static IWebHost BuildWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseDefaultServiceProvider(options => options.ValidateScopes = false).Build();
    }
}