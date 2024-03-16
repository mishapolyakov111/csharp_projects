using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public GroupAddressee(IReadOnlyCollection<IAddressee> addressees, string name)
    {
        _addressees = addressees;
        Name = name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}