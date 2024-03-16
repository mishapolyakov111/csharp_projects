using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddSingleton<IUserService, UserService>();

        collection.AddSingleton<ICurrentUserManager, CurrentUserManager>();

        return collection;
    }
}