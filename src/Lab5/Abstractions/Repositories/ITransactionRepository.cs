using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;

namespace Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;

public interface ITransactionRepository
{
    IEnumerable<BankTransaction> GetUserTransactionHistory(int id);
    void AddTransaction(BankTransaction transaction);
}