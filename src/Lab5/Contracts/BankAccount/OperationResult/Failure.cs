namespace Itmo.ObjectOrientedProgramming.Lab5.Contracts.BankAccount.OperationResult;

public record Failure(string Alarm) : OperationResult(Alarm);