using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class UserAddressee : IAddressee
{
    private readonly IUser _user;

    public UserAddressee(IUser user)
    {
        _user = user;
        Name = _user.Name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        _user.TakeMessage(message);
    }
}