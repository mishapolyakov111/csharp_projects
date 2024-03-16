using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Models.BankTransaction;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Transaction;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<BankTransaction> GetUserTransactionHistory(int id)
    {
        const string sql = """
                           select * from transaction_history
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
            int userId = reader.GetInt32(0);
            int accountId = reader.GetInt32(1);
            BankTransactionType type = reader.GetString(2) == "withdraw"
                ? BankTransactionType.Withdraw
                : BankTransactionType.Deposit;
            int money = reader.GetInt32(3);
            string result = reader.GetString(4);

            yield return new BankTransaction(type, userId, accountId, money, result);
        }
    }

    public void AddTransaction(BankTransaction transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);

        const string sql = "insert into transaction_history " +
                           "values (@userId, @accountId, @type, @money, @result, @message)";
        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);

        if (!connectionAsync.IsCompleted) return;

        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("userId", transaction.UserId);
        command.AddParameter("accountId", transaction.AccountId);
        command.AddParameter("type", transaction.BankTransactionType.ToString());
        command.AddParameter("money", transaction.Money);
        command.AddParameter("result", transaction.Result);
        command.AddParameter("message", transaction.Message);

        command.ExecuteNonQuery();

        connection.Close();
    }
}