namespace Itmo.ObjectOrientedProgramming.Lab4.Result;

public record Failure(string Message) : ExecutionResult(Message);