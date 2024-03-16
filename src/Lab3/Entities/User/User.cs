using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public class User : IUser
{
    private readonly Dictionary<Message, MessageStatus> _messageStatusMap = new();

    public User(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void ReadMessage(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (_messageStatusMap.TryGetValue(message, out MessageStatus status))
        {
            if (status == MessageStatus.Read)
            {
                throw new MessageException("Message has already been read");
            }

            _messageStatusMap.Remove(message);
            _messageStatusMap.Add(message, MessageStatus.Read);
        }
        else
        {
            throw new MessageException("User has not received such a message");
        }
    }

    public MessageStatus GetStatus(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (_messageStatusMap.TryGetValue(message, out MessageStatus status))
        {
            return status;
        }

        throw new ArgumentException("User has not received such a message");
    }

    public void TakeMessage(Message message)
    {
        _messageStatusMap.Add(message, MessageStatus.NotRead);
    }
}