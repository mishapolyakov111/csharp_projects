using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessageFilter : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly int _minImportanceLevel;

    public MessageFilter(IAddressee addressee, int minImportanceLevel)
    {
        _addressee = addressee;
        _minImportanceLevel = minImportanceLevel;
        Name = _addressee.Name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.Importance >= _minImportanceLevel)
        {
            _addressee.ReceiveMessage(message);
        }
    }
}