using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleRestAPI.infrastructure.EF.Workout;

public class WorkoutConfiguration: IEntityTypeConfiguration<WorkoutEntity>
{
  public void Configure(EntityTypeBuilder<WorkoutEntity> builder)
  {
    builder.ToTable("workouts");
    builder.HasKey(w => w.Id);
    builder.Property(w => w.Name).IsRequired();
    builder.Property(w => w.Description).IsRequired();
    
    builder.HasMany(w => w.Exercises).WithMany(e => e.Workouts).
      UsingEntity(j => j.ToTable("workout_exercises"));
  }   
}
