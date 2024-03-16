using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public class Message : IEquatable<Message>, IRenderable
{
    public Message(string? header, string? text, int importance)
    {
        ArgumentNullException.ThrowIfNull(header);
        ArgumentNullException.ThrowIfNull(text);
        Importance = importance;
        Header = header;
        Body = text;
    }

    public static IMessageBuilder Builder => new MessageBuilder();

    public string Header { get; }
    public string Body { get; }
    public int Importance { get; }

    public bool Equals(Message? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Header == other.Header && Body == other.Body && Importance == other.Importance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Body, (int)Importance);
    }

    public string Render()
    {
        return "{Title}:\n\t" + Header + "\n" + "{Body}:\n\t" + Body + "\n";
    }
}