namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public interface ILogger
{
    void LogInfo(Message.Message message, IAddressee addressee);
}