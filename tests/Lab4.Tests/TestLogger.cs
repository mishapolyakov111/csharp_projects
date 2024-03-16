using Itmo.ObjectOrientedProgramming.Lab4.Logger;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestLogger : ILogger
{
    public ExecutionResult? LastResult { get; private set; }

    public void Log(ExecutionResult result)
    {
        LastResult = result;
    }

    public void Log(string message)
    {
        throw new System.NotImplementedException();
    }
}