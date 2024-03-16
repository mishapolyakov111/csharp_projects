using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankAccountMock : IBankAccount
{
    public BankAccountMock(int id, int userId, int balance)
    {
        UserId = userId;
        Id = id;
        Balance = balance;
    }

    public int UserId { get; set; }
    public int Id { get; set; }
    public int Balance { get; set; }
}