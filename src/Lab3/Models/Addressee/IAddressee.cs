namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IAddressee
{
    string Name { get; }
    void ReceiveMessage(Message.Message message);
}