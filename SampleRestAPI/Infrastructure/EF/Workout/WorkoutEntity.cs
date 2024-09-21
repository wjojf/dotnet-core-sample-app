using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutModel = SampleRestAPI.domain.workout.Workout;

namespace SampleRestAPI.infrastructure.EF.Workout;

[Table("workouts")]
public class WorkoutEntity
{
    private WorkoutEntity(Guid id, string name, string description, List<ExerciseEntity> exercises)
    {
        Id = id;
        Name = name;
        Description = description;
        Exercises = exercises;
    }

    [Key] public Guid Id { get; init; }

    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    public List<ExerciseEntity> Exercises { get; init; }
    
    public static WorkoutEntity FromModel(WorkoutModel workout)
    {
        return new WorkoutEntity(
            workout.Id,
            workout.Name,
            workout.Description,
            workout.Exercises.Select(ExerciseEntity.FromModel).ToList()
        );
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