using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.BankAccount.OperationResult;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;
#pragma warning restore IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;

namespace Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;

public interface IUserService
{
    ICurrentUserManager UserManager { get; }

    LoginResult.LoginResult Login(int id, string password);

    OperationResult WithdrawMoney(int accountId, int money);

    OperationResult DepositMoney(int accountId, int money);

    IEnumerable<BankTransaction> GetHistory(int accountId);

    IEnumerable<IBankAccount> GetUserAccounts();

    OperationResult CreateAccount(int userId);
}