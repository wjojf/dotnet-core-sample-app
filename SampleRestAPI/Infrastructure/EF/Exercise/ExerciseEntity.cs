using SampleRestAPI.domain.exercise;

namespace SampleRestAPI.infrastructure.EF;

public class ExerciseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Repetitions { get; set; }
    public int Weight { get; set; }
    public int Duration { get; set; }
    
    public List<WorkoutEntity> Workouts { get; set; }
    
    
    public static ExerciseEntity FromModel(Exercise exercise)
    {
        return new ExerciseEntity()
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Sets = exercise.Sets,
            Repetitions = exercise.Repetitions,
            Weight = exercise.Weight,
            Duration = exercise.Duration
        };
    }
    
    public Exercise ToModel()
    {
        return new Exercise(
            Id,
            Name,
            Sets,
            Repetitions,
            Weight,
            Duration
        );
    }
    
}