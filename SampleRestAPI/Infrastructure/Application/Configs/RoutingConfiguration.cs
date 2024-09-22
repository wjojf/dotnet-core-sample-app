using SampleRestAPI.Infrastructure.Api.Handlers;

namespace SampleRestAPI.infrastructure.Application.Configs;

public static class RoutingConfiguration
{

    public static void RegisterRoutes(this IEndpointRouteBuilder application)
    {
        application.MapWorkoutsRoutes();
        application.MapAuthorizationHandlers();
    }

}