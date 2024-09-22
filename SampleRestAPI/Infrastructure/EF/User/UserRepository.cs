using SampleRestAPI.Domain.User;
using UserModel = SampleRestAPI.Domain.User.User;

namespace SampleRestAPI.infrastructure.EF.User;

public class UserRepository(ApplicationDbContext context): IUsersRepository
{

    public Task<UserModel?> GetUserById(Guid id)
    {
        var user = context.Users.Find(id);
        return Task.FromResult(user?.ToModel());
    }

    public Task<UserModel?> GetUserByUsername(string username)
    {
        var user = context.Users.FirstOrDefault(u => u.Username == username);
        return Task.FromResult(user?.ToModel());
    }

    public Task<UserModel> CreateUser(UserModel user)
    {
        var entity = UserEntity.FromModel(user);
        context.Users.Add(entity);
        return Task.FromResult(context.SaveChanges()).ContinueWith(_ => entity.ToModel());
    }

    public Task<UserModel> UpdateUser(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserModel>> GetUsers()
    {
        throw new NotImplementedException();
    }
    
    public bool PasswordMatches(Guid id, string password)
    {
        var user = context.Users.Find(id);
        return user?.Password == password;
    }
}