using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class UserServiceMock : UserService
{
    public UserServiceMock()
        : base(new UserRepositoryMock(), new CurrentUserManager(), new TransactionHistoryMock(), new AccountRepositoryMock())
    {
    }
}