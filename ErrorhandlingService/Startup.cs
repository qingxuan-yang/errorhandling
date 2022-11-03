using ErrorhandlingService;
using ErrorhandlingService.BackgroundServices;
using ErrorhandlingService.Controllers;
using ErrorhandlingService.Interfaces;
using ErrorhandlingService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;

namespace TS.Microservices.HealthChecksHost
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
            services.AddGrpc();
            services.AddMvc();
            services.AddHealthChecks();
            RegisterBackgroundService(services);
            RegisterService(services);
        }

        private static void RegisterBackgroundService(IServiceCollection services)
        {
            services.AddHostedService<BackgroundService>();
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddSingleton<IWarningReport, WarningReportController>();
        }


            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMetricServer();
            app.UseHttpMetrics();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<ErrorService>();
                endpoints.MapControllers();

            });
        }
    }
}
