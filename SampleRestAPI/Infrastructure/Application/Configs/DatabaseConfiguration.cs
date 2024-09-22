using Microsoft.EntityFrameworkCore;
using SampleRestAPI.infrastructure.EF;

namespace SampleRestAPI.infrastructure.Application.Configs;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("postgres"));
        });
    }
}