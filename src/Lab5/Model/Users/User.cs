namespace Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

public class User
{
    public User(int id, string password, UserRole role)
    {
        Password = password;
        Role = role;
        Id = id;
    }

    public string Password { get; }
    public UserRole Role { get; }
    public int Id { get; }
}