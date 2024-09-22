using SampleRestAPI.Domain.User;
using SampleRestAPI.domain.workout;
using SampleRestAPI.infrastructure.EF.User;
using SampleRestAPI.infrastructure.EF.Workout;

namespace SampleRestAPI.infrastructure.Application.DI;

public static class DependencyContainer
{
    
    public static void RegisterInternalServices(this IServiceCollection services)
    {
        services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
    }
    
}