using System;
using Itmo.ObjectOrientedProgramming.Lab3.ExternalLibrary.MyMessenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class MessengerAdapter : IMessenger
{
    private MyMessenger _messenger;

    public MessengerAdapter(MyMessenger messenger)
    {
        _messenger = messenger;
        Name = _messenger.Name;
    }

    public string Name { get; }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messenger.GetMessage(message.Render());
    }

    public void ShowMessage()
    {
        _messenger.ShowMessage();
    }
}