using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRestAPI.infrastructure.EF;

[Table("workouts_exercises_link")]
public class WorkoutExercise
{
    public int WorkoutId { get; set; }
    public int ExerciseId { get; set; }
}