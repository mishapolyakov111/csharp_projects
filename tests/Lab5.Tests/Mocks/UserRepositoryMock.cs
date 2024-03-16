using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class UserRepositoryMock : IUserRepository
{
    public IEnumerable<User> Users { get; } = new[] { new User(1000, "bib", UserRole.Client) };

    public User? FindUserById(int id)
    {
        return Users.FirstOrDefault(x => x.Id == id);
    }
}