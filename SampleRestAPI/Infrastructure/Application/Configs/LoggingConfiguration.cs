using Microsoft.AspNetCore.HttpLogging;

namespace SampleRestAPI.infrastructure.Application.Configs;

public static class LoggingConfiguration
{

    public static void ConfigureLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(logging =>
        {
            // logging.LoggingFields = HttpLoggingFields.All;
            // logging.RequestHeaders.Add("sec-ch-ua");
            // logging.ResponseHeaders.Add("MyResponseHeader");
            // logging.MediaTypeOptions.AddText("application/javascript");
            // logging.RequestBodyLogLimit = 4096;
            // logging.ResponseBodyLogLimit = 4096;
            // logging.CombineLogs = true;
        });
    }
}