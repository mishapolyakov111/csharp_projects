using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessageLogger : IAddressee
{
    private IAddressee _addressee;
    private ILogger _logger = new ConsoleLogger();

    public MessageLogger(IAddressee addressee)
    {
        _addressee = addressee;
        Name = _addressee.Name;
    }

    public MessageLogger(IAddressee addressee, ILogger logger)
    {
        _logger = logger;
        _addressee = addressee;
        Name = _addressee.Name;
    }

    public MessageLogger(IAddressee addressee, string logPath)
    {
        _addressee = addressee;
        Name = _addressee.Name;
        _logger = new FileLogger(logPath);
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        _addressee.ReceiveMessage(message);
        _logger.LogInfo(message, this);
    }
}