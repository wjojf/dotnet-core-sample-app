namespace SampleRestAPI.infrastructure.Application.Configs;

public static class SwaggerConfiguration
{
    
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
    }
    
}