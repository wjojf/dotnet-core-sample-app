namespace SampleRestAPI.domain.workout;

public class WorkoutService : IWorkoutService
{
    private readonly List<Workout> _workouts = [];

    public Task<IEnumerable<Workout>> GetAll()
    {
        return Task.FromResult(_workouts.AsEnumerable());
    }

    public Task<Workout?> Get(Guid id)
    {
        return Task.FromResult(_workouts.FirstOrDefault(w => w.Id == id));
    }

    public Task Create(Workout workout)
    {
        _workouts.Add(workout);
        return Task.CompletedTask;
    }

    public Task Update(Workout workout)
    {
        var oldWorkout = _workouts.SingleOrDefault(w => w.Id == workout.Id);
        if (oldWorkout == null)
        {
            return Task.FromException<ArgumentException>(new ArgumentException("Workout not found"));
        }
        
        _workouts.Remove(oldWorkout);
        _workouts.Add(workout);
        
        return Task.CompletedTask;
    }

    public Task Delete(Guid id)
    {
        var existingWorkout = _workouts.SingleOrDefault(w => w.Id == id);
        if (existingWorkout != null)
        {
            _workouts.Remove(existingWorkout);
        }
        return Task.CompletedTask;
    }
}