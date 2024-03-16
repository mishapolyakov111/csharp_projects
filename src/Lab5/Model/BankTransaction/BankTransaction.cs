using Itmo.ObjectOrientedProgramming.Lab5.Models.Transaction;

namespace Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;

public class BankTransaction
{
    public BankTransaction(
        BankTransactionType? bankTransactionType,
        int userId,
        int accountId,
        int money,
        string? result)
    {
        Result = result;
        BankTransactionType = bankTransactionType;
        UserId = userId;
        AccountId = accountId;
        Money = money;
    }

    public int UserId { get; }
    public int AccountId { get; }
    public BankTransactionType? BankTransactionType { get; }
    public int Money { get; }
    public string? Result { get; }
    public string? Message { get; }
}