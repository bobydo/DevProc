using Blazor.Shared.Common;
using Blazor.Shared.Model;
using Blazor.Shared.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Blazor.Server
{
    public class Startup
    {

        public IConfiguration _configuration { get; }
        //public ILoggerFactory _loggerFactory { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder.ClearProviders();
            //    builder.AddDebug();
            //    builder.AddEventLog();
            //});
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();
            services
                //.AddScoped<IEmail, Email>()
                .AddScoped<IEmailConfiguration, EmailConfiguration>()
                .AddScoped<IEmailService, EmailService>();
            services.Configure<EmailConfiguration>(_configuration.GetSection(EmailConfiguration.Section));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
