using SampleRestAPI.domain.exercise;

namespace SampleRestAPI.domain.workout;

public class Workout(Guid id, string name, string description, List<Exercise> exercises)
{
    
    public static Workout New(string name, string description)
    {
        return new Workout(Guid.NewGuid(), name, description, []);
    }
    
    public Workout WithExercises(List<Exercise> exercises)
    {
        Exercises = exercises;
        return this;
    }
    
    public Guid Id { get; private set; } = id;
    
    public string Name { get; private set; } = name;
    
    public string Description { get; private set; } = description;
    
    public List<Exercise> Exercises { get; private set; } = exercises;
    
}