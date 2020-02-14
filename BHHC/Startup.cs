using BHHC.Database;
using BHHC.Services;
using BHHC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BHHC
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add a scoped database context for persistence
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    // Read connection string from appsettings.json
                    _configuration.GetConnectionString("AppConnectionString"),
                    // Retry on failed connection
                    optionsAction => optionsAction.EnableRetryOnFailure(5));

            }, ServiceLifetime.Scoped);

            // Add support for controllers with views. 
            // This includes services required for rendering razor pages.
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            // Scoped services for interacting with our data model.
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IFantasticReasonService, FantasticReasonService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger,
            AppDbContext dbContext)
        {
            logger.LogInformation("Configuring request pipeline.");

            // Run database migrations to ensure up-to-date schema.
            logger.LogInformation("Running database migrations.");
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable delivery of static assets (js, images, stylesheets) from the wwwroot directory
            app.UseStaticFiles();

            // Enable routing and route parameter resolution.
            app.UseRouting();

            // Enable endpoint routing (map routes to controllers)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            logger.LogInformation("Pipeline configuration complete.");
        }
    }
}
