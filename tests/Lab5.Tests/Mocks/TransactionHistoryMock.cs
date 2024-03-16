using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TransactionHistoryMock : ITransactionRepository
{
    public IEnumerable<BankTransaction> GetUserTransactionHistory(int id)
    {
        return new List<BankTransaction>();
    }

    public void AddTransaction(BankTransaction transaction)
    {
        return;
    }
}