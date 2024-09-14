using WorkoutModel = SampleRestAPI.domain.workout.Workout;

namespace SampleRestAPI.infrastructure.Api.DTO.Workout;

public class WorkoutUpdateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public WorkoutModel ToModel(Guid id)
    {
        return new WorkoutModel(
            id,
            Name,
            Description,
            []
        );
    }
}