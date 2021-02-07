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


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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
