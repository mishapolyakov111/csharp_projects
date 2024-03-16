using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserById(int id);
}