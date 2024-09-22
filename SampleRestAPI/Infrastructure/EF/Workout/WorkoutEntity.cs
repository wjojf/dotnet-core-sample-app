using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutModel = SampleRestAPI.domain.workout.Workout;

namespace SampleRestAPI.infrastructure.EF.Workout;

[Table("workouts")]
public class WorkoutEntity
{
    [Key] public Guid Id { get; init; }

    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    public List<ExerciseEntity> Exercises { get; init; }
    
    public static WorkoutEntity FromModel(WorkoutModel workout)
    {
        return new WorkoutEntity()
        {
            Id = workout.Id,
            Name = workout.Name,
            Description = workout.Description,
            Exercises = workout.Exercises.Select(ExerciseEntity.FromModel).ToList()
        };
    }

    public void UpdateFromModel(WorkoutModel model)
    {
        Name = model.Name;
        Description = model.Description;
    }
    
    
    public WorkoutModel ToModel()
    {
        return new WorkoutModel(
            Id,
            Name,
            Description,
            Exercises.Select(e => e.ToModel()).ToList()
        );
    }
}