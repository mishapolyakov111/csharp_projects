using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Comands;

public interface ICommand
{
    ExecutionResult Execute(Context? context);
}