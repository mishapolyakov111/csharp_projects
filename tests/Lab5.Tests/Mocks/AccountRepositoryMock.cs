using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountRepositoryMock : IAccountRepository
{
    private IEnumerable<BankAccountMock> Accounts { get; } = new[]
    {
        new BankAccountMock(1, 1000, 1000),
        new BankAccountMock(2, 1000, 0),
    };

    public IEnumerable<IBankAccount> GetUserAccounts(int id)
    {
        return Accounts.Where(x => x.UserId == id);
    }

    public void SetBalance(int accountId, int updatedBalance)
    {
        Accounts.First(x => x.Id == accountId).Balance = updatedBalance;
    }

    public void AddAccount(int userId)
    {
        throw new System.NotImplementedException();
    }
}