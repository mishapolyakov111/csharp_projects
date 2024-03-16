namespace Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;

public class BankAccount : IBankAccount
{
    public BankAccount(int id, int userId, int money)
    {
        Balance = money;
        Id = id;
        UserId = userId;
    }

    public int Balance { get; set; }

    public int UserId { get; }
    public int Id { get; }
}