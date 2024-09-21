namespace SampleRestAPI.domain.workout;

public interface IWorkoutService
{
    Task<IEnumerable<Workout>> GetAll();
    Task<Workout?> Get(Guid id);
    Task Create(Workout workout);
    Task Update(Workout workout);
    Task Delete(Guid id);
}
