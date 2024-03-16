using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.ExternalLibrary.MyMessenger;

public class MyMessenger
{
    private IPrinter _printer;
    private List<string> _messages = new List<string>();

    public MyMessenger(IPrinter printer)
    {
        _printer = printer;
    }

    public MyMessenger()
    {
        _printer = new ConsolePrinter();
    }

    public string Name { get; } = "Woochup";

    public void ShowMessage()
    {
        _printer.Print(Name + "\n");

        foreach (string message in _messages)
        {
            _printer.Print(message + '\n');
        }
    }

    public void GetMessage(string message)
    {
        _messages.Add(message);
    }
}