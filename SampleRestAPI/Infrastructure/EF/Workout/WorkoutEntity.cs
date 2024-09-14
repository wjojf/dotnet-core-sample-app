using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleRestAPI.domain.exercise;
using SampleRestAPI.domain.workout;

namespace SampleRestAPI.infrastructure.EF;

[Table("workouts")]
public class WorkoutEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<ExerciseEntity> Exercises { get; set; }
    
    
    public static WorkoutEntity FromModel(Workout workout)
    {
        return new WorkoutEntity()
        {
            Id = workout.Id,
            Name = workout.Name,
            Description = workout.Description,
            Exercises = workout.Exercises.Select(ExerciseEntity.FromModel).ToList()
        };
    }

    public void UpdateFromModel(Workout model)
    {
        Name = model.Name;
        Description = model.Description;
    }
    
    
    public Workout ToModel()
    {
        
        List<Exercise> exercises = [];
        if (Exercises != null)
        {
            exercises = Exercises.Select(e => e.ToModel()).ToList();
        }
        
        return new Workout(
            Id,
            Name,
            Description,
            exercises
        );
    }
}