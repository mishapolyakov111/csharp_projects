using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public interface IUser
{
    string Name { get; }
    public void TakeMessage(Message message);
    void ReadMessage(Message? message);
    MessageStatus GetStatus(Message? message);
}