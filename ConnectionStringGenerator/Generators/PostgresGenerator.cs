using ConnectionStringGenerator.Abstractions;
using ConnectionStringGenerator.ConnectionStrings;

namespace ConnectionStringGenerator.Generators;

public class PostgresGenerator : IConnectionStringGenerator
{
    public void GenerateConnectionString()
    {
        var connectionString = PostgresConnectionString.Generate();
        connectionString.Print();
    }
}