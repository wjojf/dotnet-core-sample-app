namespace SampleRestAPI.Domain.User;

public class User(Guid id, string username, string password)
{
    
    private Guid _id = id;
    
    public Guid Id
    {
        get => _id;
        set => _id = value;
    }
    
    
    private string _username = username;
    
    public string Username
    {
        get => _username;
        set => _username = value;
    }
    
    private string _password = password;

    public string Password
    {
        get => _password;
        set => _password = value;
    }
    
}