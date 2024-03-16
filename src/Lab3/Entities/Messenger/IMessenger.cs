using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public interface IMessenger
{
    string Name { get; }
    void GetMessage(Message message);
    void ShowMessage();
}