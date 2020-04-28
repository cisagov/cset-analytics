using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CsetAnalytics.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CurrentDirectoryHelpers.SetCurrentDirectory();
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSetting("https_port", "8885");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
