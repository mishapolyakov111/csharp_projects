namespace Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;

public interface IBankAccount
{
    public int UserId { get; }
    public int Id { get; }
    public int Balance { get; }
}