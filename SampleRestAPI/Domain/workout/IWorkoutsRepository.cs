namespace SampleRestAPI.domain.workout;

public interface IWorkoutsRepository
{
    Task<IEnumerable<Workout>> GetAll();
    Task<Workout?> Get(Guid id);
    Task Update(Workout workout);
    
    Task Create(Workout workout);
    
    Task Delete(Guid id);
    
}