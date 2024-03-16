namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IMessageBuilder
{
    Message.Message Build();
    IMessageBuilder WithHeader(string header);
    IMessageBuilder WithBody(string body);
    IMessageBuilder WithImportanceLevel(int level);
}