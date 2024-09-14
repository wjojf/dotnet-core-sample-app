namespace SampleRestAPI.domain.exercise;

public class Exercise
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Repetitions { get; set; }
    public int Weight { get; set; }
    public int Duration { get; set; }
    
    public static Exercise New(string name, int sets, int repetitions, int weight, int duration)
    {
        return new Exercise(Guid.NewGuid(), name, sets, repetitions, weight, duration);
    }
    
    public Exercise(Guid id, string name, int sets, int repetitions, int weight, int duration)
    {
        Id = id;
        Name = name;
        Sets = sets;
        Repetitions = repetitions;
        Weight = weight;
        Duration = duration;
    }
}