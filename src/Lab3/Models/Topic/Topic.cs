namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;

public class Topic
{
    private readonly IAddressee _addressee;

    public Topic(string title, IAddressee addressee)
    {
        _addressee = addressee;
        Title = title;
    }

    public string Title { get; }

    public void SendMessage(Message.Message message)
    {
        _addressee.ReceiveMessage(message);
    }
}