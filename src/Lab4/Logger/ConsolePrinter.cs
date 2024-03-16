using System;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ConsolePrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}