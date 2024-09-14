using ExerciseModel = SampleRestAPI.domain.exercise.Exercise;

namespace SampleRestAPI.Infrastructure.Api.DTO.Exercise;

public class ExerciseCreateDTO
{
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Repetitions { get; set; }
    public int Weight { get; set; }
    public int Duration { get; set; }
    
    public ExerciseModel ToModel()
    {
        return ExerciseModel.New(
            Name,
            Sets,
            Repetitions,
            Weight,
            Duration
        );
    }
}