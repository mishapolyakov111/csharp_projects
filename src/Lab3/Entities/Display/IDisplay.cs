using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplay
{
    string Name { get; }
    void GetMessage(Message message);
    void ShowMessage();
}