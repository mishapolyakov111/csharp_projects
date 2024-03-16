using System.Threading;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Connection;

public class PostgresConnectionProvider : IPostgresConnectionProvider
{
    private readonly NpgsqlDataSource _dataSource;

    public PostgresConnectionProvider(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public PostgresConnectionProvider(string connectionString)
    {
        _dataSource = NpgsqlDataSource.Create(connectionString);
    }

    public ValueTask<NpgsqlConnection> GetConnectionAsync(CancellationToken cancellationToken)
    {
        NpgsqlConnection connection = _dataSource.CreateConnection();
        return new ValueTask<NpgsqlConnection>(connection);
    }
}