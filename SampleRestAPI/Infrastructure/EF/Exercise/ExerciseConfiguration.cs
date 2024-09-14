using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleRestAPI.infrastructure.EF;

public class ExerciseConfiguration: IEntityTypeConfiguration<ExerciseEntity>
{
    public void Configure(EntityTypeBuilder<ExerciseEntity> builder)
    {
        builder.ToTable("exercises");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Sets).IsRequired();
        builder.Property(e => e.Repetitions).IsRequired();
        
        builder.HasMany(e => e.Workouts).WithMany(w => w.Exercises).
            UsingEntity(j => j.ToTable("workout_exercises"));
        
    }
}