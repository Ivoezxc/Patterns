// Startup.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace YourApiName
{
    public class Startup
    {
        // Configuration property to access app settings
        public IConfiguration Configuration { get; }

        // Constructor to inject IConfiguration
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services, configurations, and dependencies here
            // Example: services.AddMvc();
            // Example: services.AddSingleton<IMyService, MyService>();

            // For your API, you might configure the repository here
            // Example: services.AddSingleton<ITodoRepository, TodoRepository>();

            // Enable CORS if needed
            services.AddCors();
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
                // Production-specific configuration
                // Example: app.UseExceptionHandler("/Home/Error");
                // Example: app.UseHsts();
            }

            // Common configuration for all environments
            // Example: app.UseHttpsRedirection();
            // Example: app.UseStaticFiles();

            // Enable CORS if needed
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            // Configure routing
            app.UseRouting();

            // Configure endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controllers for API endpoints
            });
        }
    }
}
