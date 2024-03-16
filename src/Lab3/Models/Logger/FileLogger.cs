using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public class FileLogger : ILogger
{
    private IPrinter _printer;

    public FileLogger(string logPath)
    {
        _printer = new FilePrinter(logPath);
    }

    public void LogInfo(Message.Message message, IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(addressee);
        _printer.Print("The message has been sent to " + addressee.Name + "\n");
        _printer.Print("Message:\n");
        _printer.Print(message.Render());
    }
}