namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessageBuilder : IMessageBuilder
{
    private string? _header;
    private string? _body;
    private int _importance;

    public Message.Message Build()
    {
        return new Message.Message(_header, _body, _importance);
    }

    public IMessageBuilder WithHeader(string header)
    {
        _header = header;
        return this;
    }

    public IMessageBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public IMessageBuilder WithImportanceLevel(int level)
    {
        _importance = level;
        return this;
    }
}