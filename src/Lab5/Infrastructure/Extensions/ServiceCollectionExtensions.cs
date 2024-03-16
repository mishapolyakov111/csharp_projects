using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection, string connectionString)
    {
        collection.AddSingleton<IPostgresConnectionProvider>(new PostgresConnectionProvider(connectionString));

        collection.AddSingleton<IUserRepository, UserRepository>();
        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<ITransactionRepository, TransactionRepository>();

        return collection;
    }
}