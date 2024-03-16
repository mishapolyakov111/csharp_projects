using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Logger;

public interface ILogger
{
    void Log(ExecutionResult result);
    void Log(string message);
}