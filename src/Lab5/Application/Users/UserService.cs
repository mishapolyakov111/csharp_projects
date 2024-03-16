using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.BankAccount.OperationResult;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users.LoginResult;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;
#pragma warning restore IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Transaction;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;
using Success = Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users.LoginResult.Success;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class UserService : IUserService
{
    private const string AccessDenied = "User does not have the rights to do this operation";
    private const string NotEnoughFounds = "Not enough funds in the account";
    private const string Failure = "Failure";
    private const string Success = "Success";

    private readonly IUserRepository _userRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;

    private readonly ICurrentUserManager _currentUserManager;

    public UserService(
        IUserRepository userRepository,
        ICurrentUserManager currentUserManager,
        ITransactionRepository transactionRepository,
        IAccountRepository accountRepository)
    {
        _userRepository = userRepository;
        _currentUserManager = currentUserManager;
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }

    public ICurrentUserManager UserManager { get => _currentUserManager; }

    public LoginResult Login(int id, string password)
    {
        User? user = _userRepository.FindUserById(id);

        if (user is null)
        {
            return new NotFound();
        }

        if (user.Password != password)
        {
            return new NotFound();
        }

        _currentUserManager.User = user;
        _currentUserManager.BankAccounts = _accountRepository.GetUserAccounts(user.Id);
        return new Success();
    }

    public OperationResult WithdrawMoney(int accountId, int money)
    {
        if (_currentUserManager.User is null)
        {
            return new UserNotFound();
        }

        if (_currentUserManager.BankAccounts is null)
        {
            return new Failure("User has no accounts");
        }

        IBankAccount? account = _currentUserManager.BankAccounts.FirstOrDefault(acc => acc.Id == accountId);

        BankTransactionBuilder builder = new BankTransactionBuilder()
            .WithTransactionType(BankTransactionType.Withdraw)
            .WithUserId(_currentUserManager.User.Id)
            .WithAccountId(accountId)
            .WithMoney(money);

        if (account is null)
        {
            builder.WithResult(Failure);
            _transactionRepository.AddTransaction(builder.Build());
            return new Failure(AccessDenied);
        }

        if (account.Balance < money)
        {
            builder.WithResult(Failure);
            _transactionRepository.AddTransaction(builder.Build());
            return new Failure(NotEnoughFounds);
        }

        _accountRepository.SetBalance(accountId, account.Balance - money);
        builder.WithResult(Success);
        _transactionRepository.AddTransaction(builder.Build());
        return new Contracts.BankAccount.OperationResult.Success();
    }

    public OperationResult DepositMoney(int accountId, int money)
    {
        if (_currentUserManager.User is null)
        {
            return new UserNotFound();
        }

        if (_currentUserManager.BankAccounts is null)
        {
            return new Failure("User has no accounts");
        }

        IBankAccount? account = _currentUserManager.BankAccounts.FirstOrDefault(acc => acc.Id == accountId);

        BankTransactionBuilder builder = new BankTransactionBuilder()
            .WithTransactionType(BankTransactionType.Withdraw)
            .WithUserId(_currentUserManager.User.Id)
            .WithAccountId(accountId)
            .WithMoney(money);

        if (account is null)
        {
            builder.WithResult(Failure);
            _transactionRepository.AddTransaction(builder.Build());
            return new Failure(AccessDenied);
        }

        _accountRepository.SetBalance(accountId, account.Balance + money);
        builder.WithResult(Success);
        _transactionRepository.AddTransaction(builder.Build());
        return new Contracts.BankAccount.OperationResult.Success();
    }

    public IEnumerable<BankTransaction> GetHistory(int accountId)
    {
        if (_currentUserManager.User is null)
        {
            return new List<BankTransaction>();
        }

        IEnumerable<BankTransaction> transactions = _transactionRepository.GetUserTransactionHistory(_currentUserManager.User.Id);
        return transactions.Where(x => x.AccountId == accountId);
    }

    public IEnumerable<IBankAccount> GetUserAccounts()
    {
        return UserManager.User is not null ? _accountRepository.GetUserAccounts(UserManager.User.Id) : new List<IBankAccount>();
    }

    public OperationResult CreateAccount(int userId)
    {
        if (_currentUserManager.User is null)
        {
            return new Failure("User not found");
        }

        if (_currentUserManager.User.Role is UserRole.Client)
        {
            return new Failure(AccessDenied);
        }

        User? user = _userRepository.FindUserById(userId);

        if (user is null)
        {
            return new UserNotFound();
        }

        _accountRepository.AddAccount(userId);

        return new Contracts.BankAccount.OperationResult.Success();
    }
}