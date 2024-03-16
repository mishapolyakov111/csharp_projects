using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class AmoledDisplay
{
    private readonly IPrinter _printer;

    public AmoledDisplay()
    {
        _printer = new ConsolePrinter();
    }

    public AmoledDisplay(IPrinter printer)
    {
        _printer = printer;
    }

    public string Name { get; } = "Amoled";

    public void Show(string text)
    {
        _printer.Print(text);
    }
}