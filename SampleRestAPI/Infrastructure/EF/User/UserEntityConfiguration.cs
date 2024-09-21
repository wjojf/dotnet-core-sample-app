using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleRestAPI.infrastructure.EF.User;

public class UserEntityConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Username).IsRequired();
        builder.HasIndex(u => u.Username).IsUnique();
        
        builder.Property(u => u.Password).IsRequired();
    }
}