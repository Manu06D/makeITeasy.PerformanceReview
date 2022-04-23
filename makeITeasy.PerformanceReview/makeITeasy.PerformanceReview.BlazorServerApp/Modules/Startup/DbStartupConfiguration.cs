using makeITeasy.PerformanceReview.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Modules.Startup
{
    public static class DbStartupConfiguration
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContextFactory<PeformanceReviewDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnectionString"))

                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                ;
            });
        }
    }
}
