namespace SampleRestAPI.Domain.User;

public interface IUsersRepository
{
    
    public Task<User?> GetUserById(Guid id);
    
    public Task<User?> GetUserByUsername(string username);
    
    public Task<User> CreateUser(User user);
    
    public Task<User> UpdateUser(User user);
    
    public Task<User> DeleteUser(Guid id);
    
    public Task<IEnumerable<User>> GetUsers();

    public bool PasswordMatches(Guid id, string password);

}