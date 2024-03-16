using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class ConsolePrinter : IPrinter
{
    public void Print(string text)
    {
        Console.Write(text);
    }
}