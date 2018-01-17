using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFContext;
using EFContext.GenericRepo;
using EFContext.Unit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFApi
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
            services.AddMvc();
            services.AddDbContext<SchoolContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.RegisterServices();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            // Singleton: This implies only a single instance will be created and shared by all consumers.
            // Scoped: This implies that one instance per scope (i.e., one instance per request to the application) will be created.
            // Transient: This implies that the components will not be shared but will be created each time they are requested.

            //services.AddSingleton<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IGenericRepository<Object>, GenericRepository<Object>>();
            // Add all other services here.
            return services;
        }
    }
}
