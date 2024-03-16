using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessageException : Exception
{
    public MessageException(string message)
        : base(message)
    {
    }

    public MessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public MessageException()
    {
    }
}