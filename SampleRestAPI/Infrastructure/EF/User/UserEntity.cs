using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserModel = SampleRestAPI.Domain.User.User;

namespace SampleRestAPI.infrastructure.EF.User;

[Table("users")]
public class UserEntity
{
    private UserEntity(Guid id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

    [Key] public Guid Id { get; set; }
    
    
    public string Username { get; set; }

    public string Password { get; set; }
    
    public static UserEntity FromModel(UserModel user)
    {
        return new UserEntity(
            user.Id,
            user.Username,
            user.Password
        );
    }
    
    public UserModel ToModel()
    {
        return new UserModel(
            Id,
            Username,
            Password
        );
    }
}