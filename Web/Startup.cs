using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Startup
    {

        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddIdentity<ApplicationUser, IdentityRole>(op => op.SignIn.RequireConfirmedAccount = false)
                   .AddEntityFrameworkStores<DataContext>()
                   .AddDefaultTokenProviders();




            //        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //.AddEntityFrameworkStores<DataContext>();
            //services.Configure<IdentityOptions>(options => 
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //});
            //          services.AddDefaultIdentity<IdentityUser>(
            //  options => options.SignIn.RequireConfirmedAccount = false)
            //.AddEntityFrameworkStores<DataContext>();


            //options => options.SignIn.RequireConfirmedAccount = false
            //options => options.SignIn.RequireConfirmedAccount = true
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "defaultRoute" ,
                    "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
