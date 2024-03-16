using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayAdapter;

public class AmoledDisplayAdapter : IDisplay
{
    private readonly AmoledDisplay _display;
    private readonly IDisplayDriver _driver;

    public AmoledDisplayAdapter(IDisplayDriver driver, AmoledDisplay display)
    {
        _driver = driver;
        _display = display;
        Name = _display.Name;
    }

    public string Name { get; }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _driver.ReadText(message.Render());
        ShowMessage();
    }

    public void ShowMessage()
    {
        _driver.ClearOutput();
        string output = _driver.GetColoredText();
        _display.Show(output);
    }
}