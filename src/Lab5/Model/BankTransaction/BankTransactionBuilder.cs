namespace Itmo.ObjectOrientedProgramming.Lab5.Models.Transaction;

public class BankTransactionBuilder
{
    private BankTransactionType? _bankTransactionType;
    private int _userId;
    private int _accountId;
    private int _money;
    private string? _result;

    public BankTransactionBuilder WithTransactionType(BankTransactionType type)
    {
        _bankTransactionType = type;
        return this;
    }

    public BankTransactionBuilder WithUserId(int id)
    {
        _userId = id;
        return this;
    }

    public BankTransactionBuilder WithAccountId(int id)
    {
        _accountId = id;
        return this;
    }

    public BankTransactionBuilder WithMoney(int money)
    {
        _money = money;
        return this;
    }

    public BankTransactionBuilder WithResult(string result)
    {
        _result = result;
        return this;
    }

    public BankTransaction.BankTransaction Build()
    {
        return new BankTransaction.BankTransaction(_bankTransactionType, _userId, _accountId, _money, _result);
    }
}