namespace SampleRestAPI.domain.exercise;

public class Exercise(Guid id, string name, int sets, int repetitions, int weight, int duration)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int Sets { get; set; } = sets;
    public int Repetitions { get; set; } = repetitions;
    public int Weight { get; set; } = weight;
    public int Duration { get; set; } = duration;

    public static Exercise New(string name, int sets, int repetitions, int weight, int duration)
    {
        return new Exercise(Guid.NewGuid(), name, sets, repetitions, weight, duration);
    }
}