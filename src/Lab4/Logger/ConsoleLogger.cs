using System;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(ExecutionResult result)
    {
        if (result is Success)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Success");
            Console.ResetColor();

            Console.WriteLine(result.Message);
        }

        if (result is Failure)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failure");
            Console.ResetColor();

            Console.WriteLine(result.Message);
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}