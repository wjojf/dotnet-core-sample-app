using Microsoft.EntityFrameworkCore;
using SampleRestAPI.infrastructure.EF.User;
using SampleRestAPI.infrastructure.EF.Workout;

namespace SampleRestAPI.infrastructure.EF;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<WorkoutEntity> Workouts => Set<WorkoutEntity>();
    public DbSet<ExerciseEntity> Exercises => Set<ExerciseEntity>();
    
    public DbSet<UserEntity> Users => Set<UserEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}