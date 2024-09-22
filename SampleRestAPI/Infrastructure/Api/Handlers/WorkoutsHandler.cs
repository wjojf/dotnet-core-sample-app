using SampleRestAPI.domain.workout;
using SampleRestAPI.infrastructure.Api.DTO.Workout;

namespace SampleRestAPI.Infrastructure.Api.Handlers;

public static class WorkoutsHandlers
{

    public static void MapWorkoutsRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/workouts", (IWorkoutsRepository service) => service.GetAll())
            .RequireAuthorization();
        
        app.MapGet("/workouts/{id}", (IWorkoutsRepository service, Guid id) => service.Get(id))
            .RequireAuthorization();
        
        app.MapPost("/workouts", (IWorkoutsRepository service, WorkoutCreateDTO workout) =>
        {
            
            var model = workout.ToModel();
            service.Create(model);

            return new Dictionary<string, string>{{"message", "Workout created"}};
        })
            .RequireAuthorization();
        
        app.MapPut("/workouts/{id}", (IWorkoutsRepository service, Guid id, WorkoutUpdateDTO workout) =>
        {
            service.Update(workout.ToModel(id));
        });
        
        app.MapDelete("/workouts/{id}", (IWorkoutsRepository service, Guid id) => service.Delete(id));
    }
    
}