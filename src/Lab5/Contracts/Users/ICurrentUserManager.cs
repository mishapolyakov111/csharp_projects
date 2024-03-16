using System.Collections.Generic;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;
#pragma warning restore IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;

public interface ICurrentUserManager
{
    User? User { get; set; }
    IEnumerable<IBankAccount>? BankAccounts { get; set; }
}