using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;
#pragma warning restore IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class CurrentUserManager : ICurrentUserManager
{
    public User? User { get; set; }
    public IEnumerable<IBankAccount>? BankAccounts { get; set; }
}