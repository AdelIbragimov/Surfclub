using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Surfclub.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new DataContext();
            DataContextInitialize.Initialize(context);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
