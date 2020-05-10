using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MvcCustomerManager.Models;
using MvcCustomerManager.Repositories;
using MvcCustomerManager.Repositories.Impl;
using MvcCustomerManager.Services;
using MvcCustomerManager.Services.Impl;
namespace MvcCustomerManager
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
            string connectionString = @"Server=localhost;Database=CustomerManager3;user id=sa;password=reallyStrongPwd123;Trusted_Connection=false;ConnectRetryCount=0";
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString));
            services.AddControllersWithViews();
            services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();
            services.AddScoped<IProvinceRepository, ProvinceRepositoryImpl>();
            services.AddScoped<ICustomerService, CustomerServiceImpl>();
            services.AddScoped<IProvinceService, ProvinceServiceImpl>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
