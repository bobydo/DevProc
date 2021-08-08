using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("The Blazor App has started!");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, logging)=> {
                logging.ClearProviders();
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                //https://github.com/serilog/serilog-extensions-logging-file
                logging.AddFile(context.Configuration.GetSection("Logging"));
                //appsettings.Development.json has higher priority
                //logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); 
                logging.AddDebug(); // only show up on debug output
                logging.AddConsole(); // only show up on console
                //EventSource,EventLog,TraceSource,AzureAppServiceFile,AzureAppServiceBlog,ApplicationInsights

            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
