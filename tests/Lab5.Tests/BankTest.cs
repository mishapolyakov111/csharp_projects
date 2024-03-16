using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.BankAccount.OperationResult;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTest
{
    private readonly IUserService _userService = new UserServiceMock();

    [Fact]
    public void Deposit_Test()
    {
        // arrange
        _userService.Login(1000, "bib");
        int money1 = _userService.GetUserAccounts().First(x => x.Id == 1).Balance;

        // act
        OperationResult result = _userService.DepositMoney(1, 100);
        int money2 = _userService.GetUserAccounts().First(x => x.Id == 1).Balance;

        // assert
        Assert.Equal(100, money2 - money1);
        Assert.IsType<Success>(result);
    }

    [Fact]
    public void Withdraw_Success_Test()
    {
        // arrange
        _userService.Login(1000, "bib");
        int money1 = _userService.GetUserAccounts().First(x => x.Id == 1).Balance;

        // act
        OperationResult result = _userService.WithdrawMoney(1, 100);
        int money2 = _userService.GetUserAccounts().First(x => x.Id == 1).Balance;

        // assert
        Assert.Equal(100, money1 - money2);
        Assert.IsType<Success>(result);
    }

    [Fact]
    public void Withdraw_Failure_Test()
    {
        // arrange
        _userService.Login(1000, "bib");
        int money1 = _userService.GetUserAccounts().First(x => x.Id == 1).Balance;

        // act
        OperationResult result = _userService.WithdrawMoney(1, 100000);
        int money2 = _userService.GetUserAccounts().First(x => x.Id == 1).Balance;

        // assert
        Assert.Equal(money2, money1);
        Assert.IsType<Failure>(result);
    }
}