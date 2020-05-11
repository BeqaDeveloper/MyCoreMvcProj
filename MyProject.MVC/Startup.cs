using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MyProject.MVC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.Repository.Context;
using MyProject.Domain.Interfaces.Core;
using MyProject.Domain.Entities;
using MyProject.Repositories;
using MyProject.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MyProject.MVC
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
            services.AddRazorPages();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            #region Addins DBContexts
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ApplicationDbContextConnection")));
            services.AddScoped<IUnitOfWork, MyDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        Configuration.GetConnectionString("ApplicationDbContextConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();
            services.AddMvc();


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
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

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
