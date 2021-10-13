using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SquareFish.Application;
using SquareFish.Application.Services;
using SquareFish.Infrastructure;
using SquareFish.Infrastructure.Helpers;
using SquareFish.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareFish
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseNpgsql(Configuration.GetConnectionString("PsqlDbConnection")));


            services.Configure<AppSettingOptions>(Configuration.GetSection(
                              AppSettingOptions.AppSetting));
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped(typeof(IBookingLeaderRepository), typeof(BookingLeaderRepository));
            services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));
            services.AddScoped(typeof(ILeaderRepository), typeof(LeaderRepository));
            services.AddScoped(typeof(IBookingService), typeof(BookingService));

        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // Migrations
            app.UseMigrationRunner();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
        public class AppSettingOptions
        {
            public const string AppSetting = "appSetting";
            public TimeSpan BackgroundJobsShutdownTimeout { get; set; }
        }
    }
}
