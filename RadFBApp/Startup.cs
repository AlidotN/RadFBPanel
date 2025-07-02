using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Services;
using System.Threading;

namespace RadFBApp
{

    public class Startup
    {
        IConfigurationRoot configurationRoot;

        public Startup(IHostingEnvironment env)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                  .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews(); // ✔️ routing جدید
            services.AddRazorPages();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddTransient<ApplicationDbContext>();

            services.AddTransient<IEmailSender, MessageServices>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Panel/Account/Login";
                options.LogoutPath = "/Panel/Account/LogOff";
                options.AccessDeniedPath = "/Panel/Account/Login";
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.SlidingExpiration = true;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                string cookie = string.Empty;
                if (context.Request.Cookies.TryGetValue("Language", out cookie))
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie);
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie);
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa");
                }
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Panel",
                    areaName: "Panel",
                    pattern: "Panel/{controller=Account}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "User",
                    areaName: "User",
                    pattern: "User/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
