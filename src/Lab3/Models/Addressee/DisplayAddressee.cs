using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayAddressee : IAddressee
{
    private IDisplay _display;

    public DisplayAddressee(IDisplay display)
    {
        _display = display;
        Name = _display.Name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        _display.GetMessage(message);
    }
}