using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankAccounts;
#pragma warning restore IDE0005

// Снова почему-то ругается на узинг
#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
#pragma warning restore IDE0005
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<IBankAccount> GetUserAccounts(int id)
    {
        const string sql = """
                           select account_id, user_id, balance
                           from bank_accounts
                           where user_id = :id;
                           """;
        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider
            .GetConnectionAsync(default);

        if (!connectionAsync.IsCompleted) yield break;

        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new BankAccount(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetInt32(2));
        }
    }

    public void SetBalance(int accountId, int updatedBalance)
    {
        const string sql = """ update bank_accounts set balance =:updatedBalance where account_id =:accountId""";
        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);

        if (!connectionAsync.IsCompleted) return;

        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("updatedBalance", updatedBalance);
        command.AddParameter("accountId", accountId);

        command.ExecuteNonQuery();

        connection.Close();
    }

    public void AddAccount(int userId)
    {
        const string sql = "insert into bank_accounts (user_id) values (@id)";
        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);

        if (!connectionAsync.IsCompleted) return;

        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("id", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        connection.Close();
    }
}