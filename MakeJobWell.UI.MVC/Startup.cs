using FluentValidation.AspNetCore;
using MakeJobWell.BLL.Concrete.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using Hangfire;
using Hangfire.PostgreSql;
using MakeJobWell.Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace MakeJobWell.UI.MVC
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration conf)
        {
            configuration = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblyContaining<Startup>();
            });


            services.AddMvc(options =>
            {
                options.Filters.Add(new CustomHandlerExceptionFilterAttribute() { ErrorPage = "~/Views/Error/CustomError.cshtml" });
            });
            //services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(100);
            //    options.ExcludedHosts.Add("www.localhost:59143");
            //    options.ExcludedHosts.Add("localhost:59143");
            //    options.ExcludedHosts.Add("http://localhost:59143");
            //    options.ExcludedHosts.Add("http://www.localhost:59143");
            //});

            services.AddHangfire(config => config.UsePostgreSqlStorage(configuration.GetConnectionString("HangFireConnection")));

            services.AddHangfireServer();

            services.AddScopedBLL();
            services.AddScoped();

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a => a.LoginPath = new PathString("/Login/Index"));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //app.UseStatusCodePages("text/plain", "Error Status Code : {0}");
                app.UseStatusCodePages(async context =>
                {
                    context.HttpContext.Response.ContentType = "text/plain";
                    await context.HttpContext.Response.WriteAsync($" Page Not Found  ,Error Status Code : {context.HttpContext.Response.StatusCode}");
                });

                logger.LogInformation("In Development");
            }
            else
            {
                //app.UseExceptionHandler("/Error/Error");
                app.UseHsts();

                logger.LogInformation("Not In Development");
            }
            //app.UseExceptionHandler("/Error/Error");
            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseHangfireDashboard(pathMatch: "/hangfire");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapAreaControllerRoute(
                    name: "adminArea",
                    areaName: "Admin",
                    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "adminArea",
                //    pattern: "{area=Admin}/{controller=Admin}/{action=Index}/{id?}");
            });
        }
    }
}
