using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class MessageAddressee : IAddressee
{
    private IMessenger _messenger;

    public MessageAddressee(IMessenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);
        _messenger = messenger;
        Name = _messenger.Name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messenger.GetMessage(message);
    }
}