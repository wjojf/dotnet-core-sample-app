using SampleRestAPI.infrastructure.Application.Configs;

namespace SampleRestAPI.infrastructure.Application.Configs;

public static class WebApplicationConfiguration
{
    
    public static void Configure(WebApplication app)
    {
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        
        app.UseHttpsRedirection();
        
        app.UseHttpLogging();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.RegisterRoutes();
    }
}