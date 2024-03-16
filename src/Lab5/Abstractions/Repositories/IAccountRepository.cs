using System.Collections.Generic;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;
#pragma warning restore IDE0005

namespace Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;

public interface IAccountRepository
{
    IEnumerable<IBankAccount> GetUserAccounts(int id);
    void SetBalance(int accountId,  int updatedBalance);
    void AddAccount(int userId);
}