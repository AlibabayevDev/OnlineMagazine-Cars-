using OnlineMagazine.Data;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Models.Entities;
using OnlineMagazine.Data.Repository;
using OnlineMagazine.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Repository;
using OnlineMagazine.IdentityServer;
using System;
using OnlineMagazine.Core.Repository;

namespace OnlineMagazine
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(s => ShopCart.GetCart(s));

            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IPasswordHasher<User>, CustomPasswordHasher>();
            services.AddIdentity<User, Role>();
            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();



            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            


            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{ id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObjects.Initial(content);

            }

        }
    }
}
