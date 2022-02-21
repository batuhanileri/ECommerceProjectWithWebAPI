using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using Core.Services;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess;
using DataAccess.Concrete.EntityFramework;
using DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiService;
using WebAPIWithCoreMvc.Mapping;

namespace WebAPIWithCoreMvc
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
            services.AddHttpContextAccessor();
            services.AddHttpClient<CategoryApiService>(opt => {

                opt.BaseAddress = new Uri(Configuration["baseUrl"]);

            });
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                
            });

            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x=>
                {
                    x.LoginPath = "/Auth/Login";
                }
                );
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Auth/Login"; ;
                options.SlidingExpiration = true;
            });
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //// services.AddScoped<ICategoryDal, EfCategoryDal>();

            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<IProductService, ProductManager>();
            //services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<>));
            //services.AddScoped(typeof(IService<>), typeof(Service<>));

            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString()
            //        , o => { o.MigrationsAssembly("DataAccess"); });

            //});
            services.AddAutoMapper(typeof(MapProfile));

            services.AddSession();
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
            app.UseSession();
            app.UseCookiePolicy();
            app.UseRouting();

          
            app.UseAuthentication();

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
