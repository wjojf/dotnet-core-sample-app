using SampleRestAPI.infrastructure.Application.Configs;
using SampleRestAPI.infrastructure.Application.DI;

namespace SampleRestAPI.infrastructure.Application;

public static class ApplicationBundle
{

    public static void Configure(this WebApplication app)
    {
       WebApplicationConfiguration.Configure(app);
    }
    
    public static void Prepare(this WebApplicationBuilder builder)
    {
       builder.Services.ConfigureDatabase(builder.Configuration);
       
       builder.Services.ConfigureJwt(builder.Configuration);
       
       builder.Services.ConfigureSwagger();
       
       builder.Services.RegisterInternalServices(builder.Configuration);
    }
    
}