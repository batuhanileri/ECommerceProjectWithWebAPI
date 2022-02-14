using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using Core.Services;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Mapping;
namespace WebApi
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
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSwaggerDocument();

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
           // services.AddScoped<ICategoryDal, EfCategoryDal>();

            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<IProductService, ProductManager>();
            //services.AddScoped<IAdminService, AdminManager>();
            //services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<>));
            //services.AddScoped(typeof(IService<>), typeof(Service<>));
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString()
                    , o => { o.MigrationsAssembly("DataAccess"); });

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
