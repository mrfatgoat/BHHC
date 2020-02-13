using BHHC.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace BHHC
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

            services.AddRazorPages();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger,
            AppDbContext dbContext)
        {
            logger.LogInformation("Configuring request pipeline.");

            // DEVNOTE: run database migrations to ensure up-to-date schema
            logger.LogInformation("Running database migrations.");
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            logger.LogInformation("Pipeline configuration complete.");
        }
    }
}
