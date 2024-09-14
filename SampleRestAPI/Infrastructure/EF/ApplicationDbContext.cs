using Microsoft.EntityFrameworkCore;

namespace SampleRestAPI.infrastructure.EF;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<WorkoutEntity> Workouts => Set<WorkoutEntity>();
    public DbSet<ExerciseEntity> Exercises => Set<ExerciseEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
    }
}