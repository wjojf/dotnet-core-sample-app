using Microsoft.EntityFrameworkCore;
using SampleRestAPI.domain.workout;
using SampleRestAPI.infrastructure.EF;
using SampleRestAPI.infrastructure.Handlers;

namespace SampleRestAPI.infrastructure;

public static class ApplicationBundle
{

    public static void RegisterServices(WebApplicationBuilder builder)
    {

        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));
        });

        builder.Services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
    }
    
    public static void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        
        RegisterHandlers(app);
    }
    
    private static void RegisterHandlers(IEndpointRouteBuilder app)
    {
        app.MapWorkoutsRoutes();
    } 
    
}