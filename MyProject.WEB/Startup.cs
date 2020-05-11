using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repositories;
using MyProject.Repository.Context;
using MyProject.Services;
using MyProject.WEB.Areas.Identity.Data;

namespace MyProject.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            #region Adding Connection String for Migration 
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ApplicationDbContextConnection")));
            services.AddScoped<IUnitOfWork, MyDbContext>();
            #endregion

            #region adding dependencies
            var interfaces = typeof(Test).Assembly.GetTypes().Where(t => t.IsInterface && t != typeof(IUnitOfWork));
            //Add Repository Dependencies
            foreach (var t in typeof(TestRepository).Assembly.GetTypes())
            {
                foreach (var i in interfaces.Where(x => x.IsAssignableFrom(t)))
                {
                    services.AddScoped(i, t);
                }
            }
            //Add Service Dependencies
            foreach (var s in typeof(TestService).Assembly.GetTypes())
            {
                foreach (var i in interfaces.Where(x => x.IsAssignableFrom(s)))
                {
                    services.AddScoped(i, s);
                }
            }
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
