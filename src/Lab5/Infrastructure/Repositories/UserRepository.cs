using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserById(int id)
    {
        string sql = "select user_id, user_role, user_password from users where user_id =:id;";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider
            .GetConnectionAsync(default);

        if (!connectionAsync.IsCompleted) return null;

        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();

        int userId = reader.GetInt32(0);
        string roleString = reader.GetString(1);
        string password = reader.GetString(2);

        UserRole role = roleString == "client" ? UserRole.Client : UserRole.Admin;

        connection.Close();
        return new User(userId, password, role);
    }
}