using WorkoutModel = SampleRestAPI.domain.workout.Workout;

namespace SampleRestAPI.infrastructure.Api.DTO.Workout;

public class WorkoutCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public WorkoutModel ToModel()
    {
        return WorkoutModel.New(
            Name,
            Description
        );
    }
}