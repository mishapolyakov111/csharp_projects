using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.ExternalLibrary.MyMessenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessageTests
{
    [Fact]
    public void SendMessage_MessageShouldBeNotRead_WhenAddresseeIsUser()
    {
        // Arrange
        var user = new User("Michael");
        var userAddressee = new UserAddressee(user);
        var topic = new Topic("Family", userAddressee);
        Message message = Message.Builder
            .WithHeader("Dinner")
            .WithBody("I want chicken")
            .Build();

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Equal(MessageStatus.NotRead, user.GetStatus(message));
    }

    [Fact]
    public void SendMessage_MessageShouldBeRead_WhenAddresseeIsUser()
    {
        // Arrange
        var user = new User("Michael");
        var userAddressee = new UserAddressee(user);
        var topic = new Topic("Family", userAddressee);
        Message message = Message.Builder
            .WithHeader("Dinner")
            .WithBody("I want chicken")
            .Build();

        // Act
        topic.SendMessage(message);
        user.ReadMessage(message);

        // Assert
        Assert.Equal(MessageStatus.Read, user.GetStatus(message));
    }

    [Fact]
    public void SendMessage_MessageShouldThrowException_WhenAddresseeIsUser()
    {
        // Arrange
        var user = new User("Michael");
        var userAddressee = new UserAddressee(user);
        var topic = new Topic("Family", userAddressee);
        Message message = Message.Builder
            .WithHeader("Dinner")
            .WithBody("I want chicken")
            .Build();

        // Act
        topic.SendMessage(message);
        user.ReadMessage(message);

        // Assert
        Assert.Throws<MessageException>(() => user.ReadMessage(message));
    }

    [Fact]
    public void SendMessage_MessageShouldBeRejectedByFilter_WhenLoggerMocked()
    {
        // Arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        IAddressee filterAddressee = new MessageFilter(addressee, 3);

        Message message = Message.Builder
            .WithHeader("My favourite rock groups")
            .WithBody("BTS")
            .WithImportanceLevel(0)
            .Build();
        var topic = new Topic("Rock", filterAddressee);

        // Act
        topic.SendMessage(message);

        // Assert
        addressee.DidNotReceive().ReceiveMessage(message);
    }

    [Fact]
    public void Logger_ShouldLog_WhenLoggerMocked()
    {
        // Arrange
        var user = new User("Alyona");
        IAddressee addressee = new UserAddressee(user);
        ILogger logger = Substitute.For<ILogger>();
        var loggerAddressee = new MessageLogger(addressee, logger);

        Message message = Message.Builder
            .WithHeader("My favourite rock groups")
            .WithBody("BTS")
            .WithImportanceLevel(0)
            .Build();
        var topic = new Topic("Rock", loggerAddressee);

        // Act
        topic.SendMessage(message);

        // Assert
        logger.Received().LogInfo(message, loggerAddressee);
    }

    [Fact]
    public void Messenger_ShouldPrint_WhenPrinterMocked()
    {
        // Arrange
        IPrinter printer = Substitute.For<IPrinter>();
        var messenger = new MyMessenger(printer);
        IMessenger adapter = new MessengerAdapter(messenger);
        IAddressee addressee = new MessageAddressee(adapter);

        Message message = Message.Builder
            .WithHeader("My favourite rock groups")
            .WithBody("BTS")
            .WithImportanceLevel(0)
            .Build();
        var topic = new Topic("Rock", addressee);

        // Act
        topic.SendMessage(message);
        messenger.ShowMessage();

        // Assert
        printer.Received().Print(messenger.Name + '\n');
    }
}