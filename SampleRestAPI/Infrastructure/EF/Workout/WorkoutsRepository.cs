using Microsoft.EntityFrameworkCore;
using SampleRestAPI.domain.workout;
using WorkoutModel = SampleRestAPI.domain.workout.Workout;

namespace SampleRestAPI.infrastructure.EF.Workout;

public class WorkoutsRepository(ApplicationDbContext context) : IWorkoutsRepository
{
    public Task<IEnumerable<WorkoutModel>> GetAll()
    {
        var workouts = context.Workouts.
                Include(e => e.Exercises).
                ToList();
        
        return Task.FromResult(workouts.Select(w => w.ToModel()));
    }
    
    public Task<WorkoutModel?> Get(Guid id)
    {
        var workout = context.Workouts.
            Include(e => e.Exercises).
            First(e => e.Id == id);
           
        return Task.FromResult(workout?.ToModel());
    }
    
    public Task Update(WorkoutModel workout)
    {
        var entity = context.Workouts.Find(workout.Id);
        if (entity == null)
        {
            throw new Exception("Workout not found");
        }
        
        entity.UpdateFromModel(workout);
        
        return Task.FromResult(context.SaveChanges());
    }
    public Task Create(WorkoutModel workout)
    {
        var entity = WorkoutEntity.FromModel(workout);
        context.Workouts.Add(entity);
        return Task.FromResult(context.SaveChanges());
    }
    
    public Task Delete(Guid id)
    {
        var entity = context.Workouts.Find(id);
        if (entity == null)
        {
            throw new Exception("Workout not found");
        }
        
        context.Workouts.Remove(entity);
        return Task.FromResult(context.SaveChanges());
    }
    
}